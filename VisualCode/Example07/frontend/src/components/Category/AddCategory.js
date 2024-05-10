import { makeStyles } from "@mui/styles";
import React, { useEffect, useState } from "react";
import { GET_ALL_CATEGORIES, POST_ADD_CATEGORY } from "../../api/apiService";
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

export default function AddCategory() {
  const classes = useStyles();
  const [checkAdd, setCheckAdd] = useState(false);



  const [name, setName] = useState(null);
  const [parentId, setParentId] = useState(null);
  const [categoryDescription, setCategoryDescription] = useState(null);
  const [icon, setIcon] = useState(null);
  const [image, setImage] = useState(null);
  const [category, setCategory] = useState({});

  // useEffect(() => {
  //   GET_ALL_CATEGORIES('Category', { parent_id : null }).then(item => {
  //     setCategory(item.data);
  //   });
  // }, [])

  //Lay parent_id cha
  const fetchDataWithCondition = async () => {
    const response = await GET_ALL_CATEGORIES('Category');
    const filteredData = response.data.filter(item => item.parent_id === null);
    setCategory(filteredData);
  };
  
  useEffect(() => {
    fetchDataWithCondition();
  }, []);
  

  const handleChangeName = (e) => {
    setName(e.target.value);
  };
  const handleChangeParentId = (e) => {
    setParentId(e.target.value);
  };
  const handleChangeCategoryDescription = (e) => {
    setCategoryDescription(e.target.value);
  };
  const handleChangeIcon = (e) => {
    setIcon(e.target.value);
  };
  const handleChangeImage = (e) => {
    setImage(e.target.value);
  };


  const addCategory = (e) => {
    e.preventDefault();
    if (
      name !== "" &&
      parentId !== "" &&
      categoryDescription !== ""
    ) {
      let category = {
        category_name: name,
        parent_id: parentId,
        category_description: categoryDescription,
        icon,
        image
      };
      console.log("category add", category);
      POST_ADD_CATEGORY(`Category`, category).then((item) => {
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
    return <Navigate to="/admin/categories" />;
  }

  return (
    <>
      <div className={classes.root}>
        <Grid container spacing={3}>
          <Grid item xs={12}>
            <Paper className={classes.paper}>
              <Typography className={classes.title} variant="h4">
                Add Category
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
                  />
                </Grid>

                <Grid item xs={12}>
                  <Typography gutterBottom variant="subtitle1">
                    Category Description
                  </Typography>
                  <TextField
                    id="outlined-multiline-static"
                    onChange={handleChangeCategoryDescription}
                    name="Body"
                    className={classes.txtInput}
                    multiline
                    rows={4}
                    variant="outlined"
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
                    <option value="Null">Choose parent id category</option>
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
                    onClick={addCategory}
                    className={classes.submit}
                    fullWidth
                    variant="contained"
                    color="primary"
                  >
                    Add category
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
