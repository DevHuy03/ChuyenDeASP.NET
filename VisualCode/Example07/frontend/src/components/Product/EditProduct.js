import { makeStyles } from "@mui/styles";
import React, { useEffect, useState } from "react";
import {
  GET_PRODUCT_ID,
  PUT_EDIT_PRODUCT,
} from "../../api/apiService";
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
export default function EditProduct({ match, location }) {
  const classes = useStyles();
  const { id } = useParams();
  const [checkUpdate, setCheckUpdate] = useState(false);
  const [idProduct, setIdProduct] = useState(0);
  const [name, setName] = useState(null);
  const [slug, setSlug] = useState(null);
  const [body, setBody] = useState(null);
  const [saleprice, setSalePrice] = useState(null);
  const [buyingprice, setBuyingPrice] = useState(null);
  const [salepercent, setSalePercent] = useState("");
  useEffect(() => {
    GET_PRODUCT_ID(`Product`, id).then((product) => {
      console.log(product);
      setIdProduct(product.data.id);
      setName(product.data.product_name);
      setSlug(product.data.slug);
      setBody(product.data.product_description);
      setSalePrice(product.data.sale_price);
      setBuyingPrice(product.data.buying_price);
      setSalePercent(product.data.sale_percent);
    });
  }, []);
  const handleChangeName = (e) => {
    setName(e.target.value);
  };
  const handleChangeSlug = (e) => {
    setSlug(e.target.value);
  };
  const handleChangeBody = (e) => {
    setBody(e.target.value);
  };
  const handleChangeSalePrice = (e) => {
    setSalePrice(e.target.value);
  };
  const handleChangeBuyingPrice = (e) => {
    setBuyingPrice(e.target.value);
  };
  const editProduct = (e) => {
    e.preventDefault();
    if (name !== "" && slug !== "" && body !== "" && saleprice !== "" && buyingprice !== "") {
      let product = {
        product_name: name,
        slug,
        product_description: body,
        sale_price: saleprice,
        buying_price: buyingprice,
        sale_percent: salepercent
      };
      PUT_EDIT_PRODUCT(`Product/${idProduct}`, product).then((item) => {
        if (item.data === 1) {
          setCheckUpdate(true);
        }
      });
    } else {
      alert("Bạn chưa nhập đầy đủ thông tin!");
    }
  };

  if (checkUpdate) {
    return <Navigate to="/admin" />;
  }
  return (
    <div className={classes.root}>
      <Grid container spacing={3}>
        <Grid item xs={12}>
          <Paper className={classes.paper}>
            <Typography className={classes.title} variant="h4">
              Edit Product
            </Typography>
            <Grid container spacing={3}>
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
                  value={name}
                />
              </Grid>
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
                  value={slug}
                />
              </Grid>
              <Grid item xs={12}>
                <Typography gutterBottom variant="subtitle1">
                  Body
                </Typography>
                <TextField
                  id="outlined-multiline-static"
                  onChange={handleChangeBody}
                  name="Body"
                  className={classes.txtInput}
                  multiline
                  rows={4}
                  defaultValue={body}
                  variant="outlined"
                />
              </Grid>
              <Grid item xs={6}>
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
                  value={saleprice}
                />
              </Grid>
              <Grid item xs={6}>
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
                  value={buyingprice}
                />
              </Grid>
              <Grid item xs={12}>
                <Button
                  type="button"
                  onClick={editProduct}
                  className={classes.submit}
                  fullWidth
                  variant="contained"
                  color="primary"
                >
                  Edit product
                </Button>
              </Grid>
            </Grid>
          </Paper>
        </Grid>
      </Grid>
    </div>
  );
}
