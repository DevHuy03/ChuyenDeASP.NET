import { makeStyles } from "@mui/styles";
import React, { useEffect, useState } from "react";
import {
  GET_PRODUCT_ID,
  PUT_EDIT_PRODUCTS,
} from "../api/apiService";
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
  const [title, setTitle] = useState(null);
  const [body, setBody] = useState(null);
  const [price, setPrice] = useState(null);
  useEffect(() => {
    GET_PRODUCT_ID(`products`, id).then((product) => {
      console.log(product);
      setIdProduct(product.data.id);
      setTitle(product.data.title);
      setBody(product.data.body);
      setPrice(product.data.price);
    });
  }, []);
  const handleChangeTitle = (e) => {
    setTitle(e.target.value);
  };
  const handleChangeBody = (e) => {
    setBody(e.target.value);
  };
  const handleChangePrice = (e) => {
    setPrice(e.target.value);
  };
  const editProduct = (e) => {
    e.preventDefault();
    if (title !== "" && body !== "" && price !== "") {
      let product = {
        title,
        body: body,
        price,
      };
      PUT_EDIT_PRODUCTS(`products/${idProduct}`, product).then((item) => {
        if (item.status === 200) {
          setCheckUpdate(true);
        }
      });
    } else {
      alert("Bạn chưa nhập đầy đủ thông tin!");
    }
  };

  if (checkUpdate) {
    return <Navigate to="/" />;
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
                  Title
                </Typography>
                <TextField
                  id="Title"
                  onChange={handleChangeTitle}
                  name="Title"
                  variant="outlined"
                  className={classes.txtInput}
                  size="small"
                  value={title}
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
              <Grid item xs={12}>
                <Typography gutterBottom variant="subtitle1">
                  Price
                </Typography>
                <TextField
                  id="Price"
                  onChange={handleChangePrice}
                  name="Price"
                  variant="outlined"
                  className={classes.txtInput}
                  size="small"
                  value={price}
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
