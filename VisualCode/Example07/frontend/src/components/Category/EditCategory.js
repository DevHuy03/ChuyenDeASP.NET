import { makeStyles } from "@mui/styles";
import React, { useEffect, useState } from "react";
import {
  GET_ALL_CATEGORIES,
  GET_CATEGORY_ID,
  PUT_EDIT_CATEGORY,
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
export default function EditCategory({ match, location }) {
  const classes = useStyles();
  const { id } = useParams();
  const [checkUpdate, setCheckUpdate] = useState(false);
  const [idCategory, setIdCategory] = useState(0);
  const [name, setName] = useState(null);
  const [categoryDescription, setCategoryDescription] = useState(null);
  const [icon, setIcon] = useState(null);
  const [image, setImage] = useState(null);
  const [parentId, setParentId] = useState(null);
  const [category, setCategory] = useState({});

  //Lay parent_id cha
  const fetchDataWithCondition = async () => {
    const response = await GET_ALL_CATEGORIES('Category');
    const filteredData = response.data.filter(item => item.parent_id === null);
    setCategory(filteredData);
  };
  useEffect(() => {
    fetchDataWithCondition();
  }, []);

  useEffect(() => {
    GET_CATEGORY_ID(`Category`, id).then((category) => {
      console.log(category);
      setIdCategory(category.data.id);
      setName(category.data.category_name);
      setCategoryDescription(category.data.category_description);
      setIcon(category.data.icon);
      setImage(category.data.image);
      setParentId(category.data.parent_id);
    });
  }, []);

  const handleChangeName = (e) => {
    setName(e.target.value);
  };
  const handleChangCategoryDescription = (e) => {
    setCategoryDescription(e.target.value);
  };
  const handleChangeIcon = (e) => {
    setIcon(e.target.value);
  };
  const handleChangeImage = (e) => {
    setImage(e.target.value);
  };
  const handleChangeParentId = (e) => {
    setParentId(e.target.value);
  };

  const editCategory = (e) => {
    e.preventDefault();
    if (name !== "" && icon !== "" && categoryDescription !== "") {
      let category = {
        category_name: name,
        category_description: categoryDescription,
        icon,
        image,
        parent_id: parentId
      };
      PUT_EDIT_CATEGORY(`Category/${idCategory}`, category).then((item) => {
        if (item.data === 1) {
          setCheckUpdate(true);
        }
      });
    } else {
      alert("Bạn chưa nhập đầy đủ thông tin!");
    }
  };

  if (checkUpdate) {
    return <Navigate to="/admin/categories" />;
  }
  return (
    <div className={classes.root}>
      <Grid container spacing={3}>
        <Grid item xs={12}>
          <Paper className={classes.paper}>
            <Typography className={classes.title} variant="h4">
              Edit Category
            </Typography>
            <Grid container spacing={3}>
              <Grid item xs={12}>
                <Typography gutterBottom variant="subtitle1">
                  Category Name
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
                  Category Description
                </Typography>
                <TextField
                  id="outlined-multiline-static"
                  onChange={handleChangCategoryDescription}
                  name="Description"
                  className={classes.txtInput}
                  multiline
                  rows={4}
                  defaultValue={categoryDescription}
                  variant="outlined"
                />
              </Grid>

              <Grid item xs={12}>
                <Typography gutterBottom variant="subtitle1">
                  Icon Category
                </Typography>
                <TextField
                  id="Icon"
                  onChange={handleChangeIcon}
                  name="Icon"
                  variant="outlined"
                  className={classes.txtInput}
                  size="small"
                  value={icon}
                />
              </Grid>

              <Grid item xs={12}>
                <Typography gutterBottom variant="subtitle1">
                  Image Category
                </Typography>
                <TextField
                  id="Image"
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
                  Choose Parent Id Category
                </Typography>
                <TextField
                  id="outlined-select-currency-native"
                  name="idCategory"
                  select
                  value={parentId}
                  onChange={handleChangeParentId}
                  SelectProps={{
                    native: true,
                  }}
                  helperText=" "
                  variant="outlined"
                  className={classes.txtInput}
                >
                  <option value={parentId}>Choose parent id category</option>
                  {category.length > 0 && category.map((cat) => (
                    <option key={cat.id} value={cat.id}>
                      {cat.category_name}
                    </option>
                  ))}
                </TextField>
              </Grid>

              <Grid item xs={12}>
                <Button
                  type="button"
                  onClick={editCategory}
                  className={classes.submit}
                  fullWidth
                  variant="contained"
                  color="primary"
                >
                  Edit Category
                </Button>
              </Grid>
            </Grid>
          </Paper>
        </Grid>
      </Grid>
    </div>
  );
}
