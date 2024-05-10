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
import { DELETE_GALLERY_ID, GET_ALL_GALLERY, GET_ALL_PRODUCTS } from '../../api/apiService';
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
export default function IndexGallery() {
    const classes = useStyles();
    const [checkDeleteGallery, setCheckDeleteGallery] = useState(false);
    const [setClose] = React.useState(false);

    const [gallery, setGallery] = useState({});
    const [product, setProduct] = useState({});
    useEffect(() => {
        GET_ALL_PRODUCTS(`Product`).then(item => {
            console.log("Product data:", item.data);
            setProduct(item.data);
        });
    }, []);
    
    useEffect(() => {
        GET_ALL_GALLERY(`Gallery`).then(item =>
            setGallery(item.data));
    }, [])
    const getProductName = (product_ID) => {
        // Lấy ra category có product_ID trùng với product_ID được truyền vào
        const productNameItem = gallery.find(
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
    const deleteTagID = (id) => {
        DELETE_GALLERY_ID(`Gallery/${id}`).then(item => {
            console.log(item)
            if (item.data === 1) {
                setCheckDeleteGallery(true);
                setGallery(gallery.filter(key => key.id !== id));
            }
        })
    }
    

    return (
        <div className={classes.root}>
            <Grid container spacing={3}>
                <Grid item xs={12}>
                    <Paper className={classes.paper}>
                        {checkDeleteGallery && <Alert
                            action={
                                <IconButton
                                    aria-label="close"
                                    color="inherit"
                                    size="small"
                                    onClick={() => {
                                        setClose(true);
                                        setCheckDeleteGallery(false)
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
                                        <TableCell><b>Product</b></TableCell>
                                        <TableCell align="center"><b>Image</b></TableCell>
                                        {/* <TableCell align="center"><b>Edit</b></TableCell> */}
                                        <TableCell align="center"><b>Delete</b></TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {gallery.length > 0 && gallery.map((row) => (
                                        <TableRow key={row.id}>
                                            <TableCell component="th" scope="row">{getProductName(row.product_id)}</TableCell>
                                            <TableCell align="center">{row.image}</TableCell>
                                            {/* <TableCell align="center">
                                                <Link to={`/admin/editgalleries/${row.id}`} className={classes.removeLink}>
                                                    <Button size="small" variant="contained" color="primary">Edit</Button></Link>
                                            </TableCell> */}
                                            <TableCell align="center">
                                                <Button size="small" variant="contained" color="secondary"
                                                    onClick={() => deleteTagID(row.id)}>Remove</Button>
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