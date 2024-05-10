import { makeStyles } from "@mui/styles";
import React, { useEffect, useState } from "react";
import { GET_ALL_PRODUCTS, GET_GALLERY_ID, PUT_EDIT_GALLERY } from "../../api/apiService";
import { Navigate, useParams } from "react-router-dom";
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
const currencies = [
  {
    value: "USD",
    label: "$",
  },
  {
    value: "EUR",
    label: "€",
  },
  {
    value: "BTC",
    label: "b",
  },
  {
    value: "JPY",
    label: "y",
  },
];
export default function EditGallery({ match, location }) {
  const classes = useStyles();
  const { id } = useParams();
  const [checkUpdate, setCheckUpdate] = useState(false);
  const [idGallery, setIdGallery] = useState(0);
  const [product_id, setProductId] = useState(null);
  const [image, setImage] = useState(null);
  const [placeholder, setPlaceholder] = useState(null);
  const [products, setProducts] = useState(null);

  useEffect(() => {
    GET_ALL_PRODUCTS(`Product`).then(item =>
      setProducts(item.data));
  }, [])

  useEffect(() => {
    GET_GALLERY_ID(`Gallery`, id).then((gallery) => {
      console.log(gallery);
      setIdGallery(gallery.data.id);
      setProductId(gallery.data.product_id);
      setImage(gallery.data.image);
      setPlaceholder(gallery.data.placeholder);
    });
  }, []);

  const handleChangeProductId = (e) => {
    setProductId(e.target.value);
  };
  const handleChangeImage = (e) => {
    setImage(e.target.value);
  };
  const handleChangePlaceholder = (e) => {
    setPlaceholder(e.target.value);
  };
  const editGallery = (e) => {
    e.preventDefault();
    if (image !== "" && placeholder !== "") {
      let gallery = {
        product_id,
        image,
        placeholder
      };
      PUT_EDIT_GALLERY(`Gallery/${idGallery}`, gallery).then((item) => {
        if (item.data === 1) {
          setCheckUpdate(true);
        }
      });
    } else {
      alert("Bạn chưa nhập đầy đủ thông tin!");
    }
  };

  if (checkUpdate) {
    return <Navigate to="/admin/galleries" />;
  }

  return (
    <div className={classes.root}>
      <Grid container spacing={3}>
        <Grid item xs={12}>
          <Paper className={classes.paper}>
            <Typography className={classes.title} variant="h4">
              Edit Gallery
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
                  <option value={product_id}>{product_id}</option>
                  {products && products.map((pr) => (
                    <option key={pr.id} value={pr.id}>
                      {pr.product_name}
                    </option>
                  ))}
                </TextField>
              </Grid>

              <Grid item xs={12}>
                <Typography gutterBottom variant="subtitle1">
                  Image
                </Typography>
                <TextField
                  id="NamImagee"
                  onChange={handleChangeImage}
                  name="Image"
                  variant="outlined"
                  className={classes.txtInput}
                  size="small"
                  value={image}
                />
              </Grid>
              <Grid item xs={12}>
                <Typography gutterBottom variant="subtitle1">
                  Placeholder
                </Typography>
                <TextField
                  id="Placeholder"
                  onChange={handleChangePlaceholder}
                  name="Placeholder"
                  variant="outlined"
                  className={classes.txtInput}
                  size="small"
                  value={placeholder}
                />
              </Grid>

              <Grid item xs={12}>
                <Button
                  type="button"
                  onClick={editGallery}
                  className={classes.submit}
                  fullWidth
                  variant="contained"
                  color="primary"
                >
                  Edit Gallery
                </Button>
              </Grid>
            </Grid>
          </Paper>
        </Grid>
      </Grid>
    </div>
  );
}
