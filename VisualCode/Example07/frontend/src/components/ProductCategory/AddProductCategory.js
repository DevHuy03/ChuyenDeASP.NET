import { makeStyles } from "@mui/styles";
import React, { useEffect, useState } from "react";
import { GET_ALL_CATEGORIES, GET_ALL_PRODUCTS, POST_ADD_PRODUCT_CATEGORY } from "../../api/apiService";
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

export default function AddProductCategory() {
  const classes = useStyles();
  const [checkAdd, setCheckAdd] = useState(false);


  const [category_id, setCategoryId] = useState(null);
  const [product_id, setProductId] = useState(null);

  const [category, setCategory] = useState({});
  const [product, setProduct] = useState({});

  useEffect(() => {
    GET_ALL_CATEGORIES('Category').then(item => {
      setCategory(item.data);
    });
  }, [])
  useEffect(() => {
    GET_ALL_PRODUCTS('Product').then(item => {
      setProduct(item.data);
    });
  }, [])  

  const handleChangeCategoryId = (e) => {
    setCategoryId(e.target.value);
  };
  const handleChangeProductId = (e) => {
    setProductId(e.target.value);
  };




  const addProductCategory = (e) => {
    e.preventDefault();
    if (
      category_id !== "" &&
      product_id !== "" 
    ) {
      let product_category = {
        category_id,
        product_id
      };
      console.log("product_category add", product_category);
      POST_ADD_PRODUCT_CATEGORY(`Product_Category`, product_category).then((item) => {
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
    return <Navigate to="/admin/productcategories" />;
  }

  return (
    <>
      <div className={classes.root}>
        <Grid container spacing={3}>
          <Grid item xs={12}>
            <Paper className={classes.paper}>
              <Typography className={classes.title} variant="h4">
                Add Product Category
              </Typography>
              <Grid container spacing={3}>


                <Grid item xs={12}>
                  <Typography gutterBottom variant="subtitle1">
                    Choose Category
                  </Typography>
                  <TextField
                    id="outlined-select-currency-native"
                    name="idCategory"
                    select
                    value={category_id}
                    onChange={handleChangeCategoryId}
                    SelectProps={{
                      native: true,
                    }}
                    helperText=" "
                    variant="outlined"
                    className={classes.txtInput}
                  >
                    <option value="Null">Choose parent id category</option>
                    {category.length > 0 && category.map((cat) => (
                      <option key={cat.id} value={cat.id}>
                        {cat.category_name}
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
                    Add product category
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
