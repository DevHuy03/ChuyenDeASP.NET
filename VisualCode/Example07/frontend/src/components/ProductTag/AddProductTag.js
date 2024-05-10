import { makeStyles } from "@mui/styles";
import React, { useEffect, useState } from "react";
import { GET_ALL_PRODUCTS, GET_ALL_TAG, POST_ADD_PRODUCT_TAG } from "../../api/apiService";
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

export default function AddProductTag() {
  const classes = useStyles();
  const [checkAdd, setCheckAdd] = useState(false);


  const [tag_id, setTagId] = useState(null);
  const [product_id, setProductId] = useState(null);

  const [tag, setTag] = useState({});
  const [product, setProduct] = useState({});

  useEffect(() => {
    GET_ALL_TAG('Tag').then(item => {
      setTag(item.data);
    });
  }, [])
  useEffect(() => {
    GET_ALL_PRODUCTS('Product').then(item => {
      setProduct(item.data);
    });
  }, [])  

  const handleChangeTagId = (e) => {
    setTagId(e.target.value);
  };
  const handleChangeProductId = (e) => {
    setProductId(e.target.value);
  };




  const addProductCategory = (e) => {
    e.preventDefault();
    if (
      tag_id !== "" &&
      product_id !== "" 
    ) {
      let product_tag = {
        tag_id,
        product_id
      };
      console.log("product_tag add", product_tag);
      POST_ADD_PRODUCT_TAG(`Product_Tag`, product_tag).then((item) => {
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
    return <Navigate to="/admin/producttags" />;
  }

  return (
    <>
      <div className={classes.root}>
        <Grid container spacing={3}>
          <Grid item xs={12}>
            <Paper className={classes.paper}>
              <Typography className={classes.title} variant="h4">
                Add Product Tag
              </Typography>
              <Grid container spacing={3}>


                <Grid item xs={12}>
                  <Typography gutterBottom variant="subtitle1">
                    Choose Tag
                  </Typography>
                  <TextField
                    id="outlined-select-currency-native"
                    name="idTag"
                    select
                    value={tag_id}
                    onChange={handleChangeTagId}
                    SelectProps={{
                      native: true,
                    }}
                    helperText=" "
                    variant="outlined"
                    className={classes.txtInput}
                  >
                    <option value="Null">Choose tag</option>
                    {tag.length > 0 && tag.map((cat) => (
                      <option key={cat.id} value={cat.id}>
                        {cat.tag_name}
                      </option>
                    ))}
                  </TextField>
                </Grid>

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
                    <option value="Null">Choose product</option>
                    {product.length > 0 && product.map((pr) => (
                      <option key={pr.id} value={pr.id}>
                        {pr.product_name}
                      </option>
                    ))}
                  </TextField>
                </Grid>

                <Grid item xs={12}>
                  <Button
                    type="button"
                    onClick={addProductCategory}
                    className={classes.submit}
                    fullWidth
                    variant="contained"
                    color="primary"
                  >
                    Add product tag
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
