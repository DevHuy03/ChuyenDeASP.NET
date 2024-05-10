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
import { DELETE_PRODUCT_TAG_ID, GET_ALL_PRODUCTS, GET_ALL_PRODUCT_TAG, GET_ALL_TAG } from '../../api/apiService';
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
export default function ProductTagIndex() {
    const classes = useStyles();
    const [tag, setTag] = useState({});
    const [product, setProduct] = useState({});
    const [producttag, setProductTag] = useState({});
    const [checkDeleteCategory, setCheckDeleteCategory] = useState(false);
    const [setClose] = React.useState(false);

    useEffect(() => {
        GET_ALL_PRODUCT_TAG(`Product_Tag`).then(item => setProductTag(item.data));
    }, [])

    const deleteProductTagID = (id) => {
        DELETE_PRODUCT_TAG_ID(`Product_Tag/${id}`).then(item => {
            console.log(item)
            if (item.data === 1) {
                setCheckDeleteCategory(true);
                setProductTag(producttag.filter(key => key.id !== id));
            }
        })
    }


    useEffect(() => {
        GET_ALL_TAG(`Tag`).then(item => setTag(item.data));
    }, []) 
    useEffect(() => {
        GET_ALL_PRODUCTS(`Product`).then(item => setProduct(item.data));
    }, [])
    
    const getTagName = (Parent_id) => {
        // Lấy ra tag có Parent_id trùng với Parent_id được truyền vào
        const parentIdCategoryItem = producttag.find(
            (item) => item.tag_id === Parent_id
        );
        if (parentIdCategoryItem) {
            // Lấy ra categoryName từ tag có id tương ứng trong tag
            const categoryId = parentIdCategoryItem.tag_id;
            const categoryItem = tag.find((item) => item.id === categoryId);
            if (categoryItem) {
                return categoryItem.tag_name;
            }
        }
        return "Null"; // Trả về rỗng nếu không tìm thấy
    };

    const getProductName = (Parent_id) => {
        // Lấy ra category có Parent_id trùng với Parent_id được truyền vào
        const parentIdCategoryItem = producttag.find(
            (item) => item.product_id === Parent_id
        );
        if (parentIdCategoryItem) {
            // Lấy ra categoryName từ category có id tương ứng trong category
            const categoryId = parentIdCategoryItem.product_id;
            const categoryItem = product.find((item) => item.id === categoryId);
            if (categoryItem) {
                return categoryItem.product_name;
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
                                        <TableCell><b>Tag Name</b></TableCell>
                                        <TableCell align="center"><b>Product Name</b></TableCell>
                                        <TableCell align="center"><b>Edit</b></TableCell>
                                        <TableCell align="center"><b>Delete</b></TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {producttag.length > 0 && producttag.map((row) => (
                                        <TableRow key={row.id}>
                                            <TableCell component="th" scope="row">{(row.tag_id)}</TableCell>
                                            <TableCell align="center">{(row.product_id)}</TableCell>
                                            <TableCell align="center">
                                                <Link to={`/admin/editcategories/${row.id}`} className={classes.removeLink}>
                                                    <Button size="small" variant="contained" color="primary">Edit</Button></Link>
                                            </TableCell>
                                            <TableCell align="center">
                                                <Button size="small" variant="contained" color="secondary"
                                                    onClick={() => deleteProductTagID(row.id)}>Remove</Button>
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