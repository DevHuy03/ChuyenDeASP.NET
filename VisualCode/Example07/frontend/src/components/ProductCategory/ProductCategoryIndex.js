import React, { useEffect, useState } from 'react';
import { makeStyles } from '@mui/styles';
import Paper from '@mui/material/Paper';
import Grid from '@mui/material/Grid';
import Alert from '@mui/material/Alert';
import IconButton from '@mui/icons-material/IosShare';
import CloseIcon from '@mui/icons-material/IosShare';
import Button from '@mui/material/Button';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import { Link } from 'react-router-dom';
import { DELETE_PRODUCT_CATEGORY_ID, GET_ALL_CATEGORIES, GET_ALL_PRODUCTS, GET_ALL_PRODUCT_CATEGORY } from '../../api/apiService';
const useStyles = makeStyles((theme) => ({
    root: {
        flexGrow: 1,
        marginTop: 20,
    },
    paper: {
        width: "100%",
        margin: "auto",
    },
    removeLink: {
        textDecoration: "none",
    }
}));
export default function ProductCategoryIndex() {
    const classes = useStyles();
    const [category, setCategory] = useState({});
    const [product, setProduct] = useState({});
    const [productcategory, setProductCategory] = useState({});
    const [checkDeleteCategory, setCheckDeleteCategory] = useState(false);
    const [setClose] = React.useState(false);

    useEffect(() => {
        GET_ALL_PRODUCT_CATEGORY(`Product_Category`).then(item => setProductCategory(item.data));
    }, [])
    // useEffect(() => {
    //     GET_ALL_PRODUCT_CATEGORY(`Product_Category`).then(item => {
    //         console.log("Product data:", item.data);
    //         setProductCategory(item.data);
    //     });
    // }, []);

    const deleteProductCategoryID = (id) => {
        DELETE_PRODUCT_CATEGORY_ID(`Product_Category/${id}`).then(item => {
            console.log(item)
            if (item.data === 1) {
                setCheckDeleteCategory(true);
                setProductCategory(productcategory.filter(key => key.id !== id));
            }
        })
    }


    useEffect(() => {
        GET_ALL_CATEGORIES(`Category`).then(item => setCategory(item.data));
    }, []) 
    useEffect(() => {
        GET_ALL_PRODUCTS(`Product`).then(item => {
            console.log("Product data:", item.data);
            setProduct(item.data);
        });
    }, []);
    
    const getParentCategoryName = (Parent_id) => {
        // Lấy ra category có Parent_id trùng với Parent_id được truyền vào
        const parentIdCategoryItem = productcategory.find(
            (item) => item.category_id === Parent_id
        );
        if (parentIdCategoryItem) {
            // Lấy ra categoryName từ category có id tương ứng trong category
            const categoryId = parentIdCategoryItem.category_id;
            const categoryItem = category.find((item) => item.id === categoryId);
            if (categoryItem) {
                return categoryItem.category_name;
            }
        }
        return "Null"; // Trả về rỗng nếu không tìm thấy
    };

    const getProductName = (product_ID) => {
        // Lấy ra category có product_ID trùng với product_ID được truyền vào
        const productNameItem = productcategory.find(
            (item) => item.product_id === product_ID
        );
        if (productNameItem) {
            // Lấy ra categoryName từ category có id tương ứng trong category
            const productid = productNameItem.product_id;
            const nameItem = product.find((item) => item.id === productid);
            if (nameItem) {
                return nameItem.product_name;
            }
        }
        return "Null"; // Trả về rỗng nếu không tìm thấy
    };

    
    return (
        <div className={classes.root}>
            <Grid container spacing={3}>
                <Grid item xs={12}>
                    <Paper className={classes.paper}>
                        {checkDeleteCategory && <Alert
                            action={
                                <IconButton
                                    aria-label="close"
                                    color="inherit"
                                    size="small"
                                    onClick={() => {
                                        setClose(true);
                                        setCheckDeleteCategory(false)
                                    }}
                                >
                                    <CloseIcon fontSize="inherit" />
                                </IconButton>
                            }
                        > Delete successfully</Alert>}
                        <TableContainer component={Paper}>
                            <Table className={classes.table} aria-label="simple table">
                                <TableHead>
                                    <TableRow>
                                        <TableCell><b>Category Name</b></TableCell>
                                        <TableCell align="center"><b>Product Name</b></TableCell>
                                        <TableCell align="center"><b>Edit</b></TableCell>
                                        <TableCell align="center"><b>Delete</b></TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {productcategory.length > 0 && productcategory.map((row) => (
                                        <TableRow key={row.id}>
                                            <TableCell component="th" scope="row">{(row.category_id)}</TableCell>
                                            <TableCell align="center">{(row.product_id)}</TableCell>
                                            <TableCell align="center">
                                                <Link to={`/admin/editcategories/${row.id}`} className={classes.removeLink}>
                                                    <Button size="small" variant="contained" color="primary">Edit</Button></Link>
                                            </TableCell>
                                            <TableCell align="center">
                                                <Button size="small" variant="contained" color="secondary"
                                                    onClick={() => deleteProductCategoryID(row.id)}>Remove</Button>
                                            </TableCell>
                                        </TableRow>
                                    ))}
                                </TableBody>
                            </Table>
                        </TableContainer>
                    </Paper>
                </Grid>
            </Grid>
        </div>
    )
}