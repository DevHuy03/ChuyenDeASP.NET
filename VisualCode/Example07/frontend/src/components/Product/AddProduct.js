import { makeStyles } from "@mui/styles";
import React, { useState } from "react";
import { POST_ADD_PRODUCT } from "../../api/apiService";
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

export default function AddProduct() {
  const classes = useStyles();
  const [checkAdd, setCheckAdd] = useState(false);


  const [slug, setSlug] = useState(null);
  const [name, setName] = useState(null);
  const [sku] = useState(null);
  const [sale_price, setSalePrice] = useState(null);
  const [buying_price, setBuyingPrice] = useState(null);
  const [sale_percent] = useState("");

  const [body, setBody] = useState(null);

  const handleChangeSlug = (e) => {
    setSlug(e.target.value);
  };
  const handleChangeName = (e) => {
    setName(e.target.value);
  };
  const handleChangeSalePrice = (e) => {
    setSalePrice(e.target.value);
  };
  const handleChangeBuyingPrice = (e) => {
    setBuyingPrice(e.target.value);
  };
  const handleChangeBody = (e) => {
    setBody(e.target.value);
  };

  const addProduct = (e) => {
    e.preventDefault();
    if (
      slug !== "" &&
      name !== "" &&
      sale_price !== "" &&
      buying_price !== "" &&
      body !== ""
    ) {
      let product = {
        slug,
        product_name: name,
        sku,
        sale_price,
        buying_price,
        sale_percent,
        product_description: body,
      };
      console.log("product add", product);
      POST_ADD_PRODUCT(`Product`, product).then((item) => {
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
    return <Navigate to="/admin" />;
  }
  
  return (
    <>
    <div className={classes.root}>
      <Grid container spacing={3}>
        <Grid item xs={12}>
          <Paper className={classes.paper}>
            <Typography className={classes.title} variant="h4">
              Add Product
            </Typography>
            <Grid container spacing={3}>
              <Grid item xs={12}>
                <Typography gutterBottom variant="subtitle1">
                  Slug
                </Typography>
                <TextField
                  id="Slug"
                  onChange={handleChangeSlug}
                  name="Slug"
                  variant="outlined"
                  className={classes.txtInput}
                  size="small"
                />
              </Grid>
              <Grid item xs={12}>
                <Typography gutterBottom variant="subtitle1">
                  Product Name
                </Typography>
                <TextField
                  id="Name"
                  onChange={handleChangeName}
                  name="Name"
                  variant="outlined"
                  className={classes.txtInput}
                  size="small"
                />
              </Grid>
              <Grid item xs={8}>
                <Typography gutterBottom variant="subtitle1">
                  Sale Price
                </Typography>
                <TextField
                  id="SalePrice"
                  onChange={handleChangeSalePrice}
                  name="SalePrice"
                  variant="outlined"
                  className={classes.txtInput}
                  size="small"
                />
              </Grid>
              <Grid item xs={8}>
                <Typography gutterBottom variant="subtitle1">
                  Buying Price
                </Typography>
                <TextField
                  id="BuyingPrice"
                  onChange={handleChangeBuyingPrice}
                  name="BuyingPrice"
                  variant="outlined"
                  className={classes.txtInput}
                  size="small"
                />
              </Grid>
              <Grid item xs={12}>
                <Typography gutterBottom variant="subtitle1">
                Product Description
                </Typography>
                <TextField
                  id="outlined-multiline-static"
                  onChange={handleChangeBody}
                  name="Body"
                  className={classes.txtInput}
                  multiline
                  rows={4}
                  variant="outlined"
                />
              </Grid>
              
              <Grid item xs={12}>
                <Button
                  type="button"
                  onClick={addProduct}
                  className={classes.submit}
                  fullWidth
                  variant="contained"
                  color="primary"
                >
                  Add product
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
