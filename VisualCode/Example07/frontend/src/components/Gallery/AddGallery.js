import { makeStyles } from "@mui/styles";
import React, { useEffect, useState } from "react";
import { GET_ALL_PRODUCTS, POST_ADD_GALLERY } from "../../api/apiService";
import { Navigate } from "react-router-dom";
import { Button, Grid, Paper, TextField, Typography } from "@mui/material";

const useStyles = makeStyles((theme) => {
  const spacing = (value) => `${value * 8}px`; // Define your custom spacing function

  return {
    root: {
      flexGrow: 1,
      marginTop: spacing(2), // Use the custom spacing function
    },
    paper: {
      padding: spacing(2),
      maxWidth: 600,
      margin: "auto",
    },
    title: {
      fontSize: 30,
      textAlign: "center",
    },
    link: {
      padding: spacing(1),
      display: "inline-block",
    },
    txtInput: {
      width: "98%",
      margin: spacing(1),
    },
    submit: {
      margin: `${spacing(3)} 0 ${spacing(2)}`,
    },
  };
});

export default function AddGallery() {
  const classes = useStyles();
  const [checkAdd, setCheckAdd] = useState(false);

  const [product_id, setProductId] = useState(null);
  const [placeholder, setPalaceholder] = useState(null);
  const [image, setImage] = useState(null)
  const [products, setProducts] = useState(null);

  useEffect(() => {
    GET_ALL_PRODUCTS(`Product`).then(item => 
      setProducts(item.data));
  }, [])

  const handleChangePlaceholder = (e) => {
    setPalaceholder(e.target.value);
  };
  const handleChangeIcon = (e) => {
    setImage(e.target.value);
  };
  const handleChangeProductId = (e) => {
    setProductId(e.target.value);
  };


  const addTag = (e) => {
    e.preventDefault();
    if (
      placeholder !== "" &&
      image !== ""
    ) {
      let gallery = {
        product_id,
        placeholder,
        image,
      };
      console.log("gallery add", gallery);
      POST_ADD_GALLERY(`Gallery`, gallery).then((item) => {
        console.log("item", item);
        if (item.data === 1) {
          setCheckAdd(true);
        }
      });
    } else {
      alert("Bạn chưa nhập đầy đủ thông tin!");
    }
  };

  if (checkAdd) {
    return <Navigate to="/admin/galleries" />;
  }

  return (
    <>
      <div className={classes.root}>
        <Grid container spacing={3}>
          <Grid item xs={12}>
            <Paper className={classes.paper}>
              <Typography className={classes.title} variant="h4">
                Add Gallery
              </Typography>
              <Grid container spacing={3}>

                <Grid item xs={12}>
                  <Typography gutterBottom variant="subtitle1">
                    Choose Product
                  </Typography>
                  <TextField
                    id="outlined-select-currency-native"
                    name="idCategory"
                    select
                    value={product_id}
                    onChange={handleChangeProductId}
                    SelectProps={{
                      native: true,
                    }}
                    helperText=" "
                    variant="outlined"
                    className={classes.txtInput}
                  >
                    {products && products.map((pr) => (
                      <option key={pr.id} value={pr.id}>
                        {pr.product_name}
                      </option>
                    ))}
                  </TextField>
                </Grid>

                <Grid item xs={12}>
                  <Typography gutterBottom variant="subtitle1">
                    Gallery Placeholder
                  </Typography>
                  <TextField
                    id="Placeholder"
                    onChange={handleChangePlaceholder}
                    name="Placeholder"
                    variant="outlined"
                    className={classes.txtInput}
                    size="small"
                  />
                </Grid>

                <Grid item xs={12}>
                  <Typography gutterBottom variant="subtitle1">
                    Icon
                  </Typography>
                  <TextField
                    id="Icon"
                    onChange={handleChangeIcon}
                    name="Icon"
                    variant="outlined"
                    className={classes.txtInput}
                    size="small"
                  />
                </Grid>

                <Grid item xs={12}>
                  <Button
                    type="button"
                    onClick={addTag}
                    className={classes.submit}
                    fullWidth
                    variant="contained"
                    color="primary"
                  >
                    Add Gallery
                  </Button>
                </Grid>
              </Grid>
            </Paper>
          </Grid>
        </Grid>
      </div>
    </>
  );
}
