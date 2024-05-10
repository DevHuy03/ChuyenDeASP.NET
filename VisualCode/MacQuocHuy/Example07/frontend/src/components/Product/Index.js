import React, { useEffect, useState } from 'react';
import { makeStyles } from '@mui/styles';
import Paper from '@mui/material/Paper';
import Grid from '@mui/material/Grid';
import Alert from '@mui/material/Alert';
// import { Redirect } from 'react-router-dom';
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
import { GET_ALL_PRODUCTS, DELETE_PRODUCT_ID } from '../../api/apiService';
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
export default function Index() {
    const classes = useStyles();
    const [products, setProducts] = useState({});
    const [checkDeleteProduct, setCheckDeleteProduct] = useState(false);
    const [setClose] = React.useState(false);

    useEffect(() => {
        GET_ALL_PRODUCTS(`Product`).then(item => setProducts(item.data));
    }, [])

    // const RawHTML = (body, className) =>
    //     <div className={className} 
    //     dangerouslySetInnerHTML={{ __html: body.replace(/\n/g, '<br />') }} 
    //     />

    const deleteProductID = (id) => {
        DELETE_PRODUCT_ID(`Product/${id}`).then(item => {
            console.log(item)
            if (item.data === 1) {
                setCheckDeleteProduct(true);
                setProducts(products.filter(key => key.id !== id));
            }
        })
    }

    return (
        <div className={classes.root}>
            <Grid container spacing={3}>
                <Grid item xs={12}>
                    <Paper className={classes.paper}>
                        {checkDeleteProduct && <Alert
                            action={
                                <IconButton
                                    aria-label="close"
                                    color="inherit"
                                    size="small"
                                    onClick={() => {
                                        setClose(true);
                                        setCheckDeleteProduct(false)
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
                                        <TableCell><b>Name</b></TableCell>
                                        <TableCell align="center"><b>Slug</b></TableCell>
                                        <TableCell align="center"><b>Title</b></TableCell>
                                        <TableCell align="center"><b>Sale Price</b></TableCell>
                                        <TableCell align="center"><b>Buying Price</b></TableCell>
                                        <TableCell align="center"><b>Edit</b></TableCell>
                                        <TableCell align="center"><b>Delete</b></TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {products.length > 0 && products.map((row) => (
                                        <TableRow key={row.id}>
                                            <TableCell component="th" scope="row">{row.product_name}</TableCell>
                                            <TableCell align="center">{row.slug}</TableCell>
                                            <TableCell align="center">{row.product_description}</TableCell>
                                            <TableCell align="center">{row.sale_price}.00$</TableCell>
                                            <TableCell align="center">{row.buying_price}.00$</TableCell>
                                            <TableCell align="center">
                                                <Link to={`/admin/editproduct/${row.id}`} className={classes.removeLink}>
                                                    <Button size="small" variant="contained" color="primary">Edit</Button></Link>
                                            </TableCell>
                                            <TableCell align="center">
                                                <Button size="small" variant="contained" color="secondary"
                                                    onClick={() => deleteProductID(row.id)}>Remove</Button>
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