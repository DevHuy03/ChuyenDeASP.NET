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
import { GET_ALL_CATEGORIES, DELETE_CATEGORY_ID } from '../../api/apiService';
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
    const [category, setCategory] = useState({});
    const [checkDeleteCategory, setCheckDeleteCategory] = useState(false);
    const [setClose] = React.useState(false);

    useEffect(() => {
        GET_ALL_CATEGORIES(`Category`).then(item => setCategory(item.data));
    }, [])

    const deleteCategoryID = (id) => {
        DELETE_CATEGORY_ID(`Category/${id}`).then(item => {
            console.log(item)
            if (item.data === 1) {
                setCheckDeleteCategory(true);
                setCategory(category.filter(key => key.id !== id));
            }
        })
    }


    const getParentCategoryName = (Parent_id) => {
        // Lấy ra category có Parent_id trùng với Parent_id được truyền vào
        const parentIdCategoryItem = category.find(
            (item) => item.id === Parent_id
        );
        if (parentIdCategoryItem) {
            // Lấy ra categoryName từ category có id tương ứng trong category
            const categoryId = parentIdCategoryItem.id;
            const categoryItem = category.find((item) => item.id === categoryId);
            if (categoryItem) {
                return categoryItem.category_name;
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
                                        <TableCell align="center"><b>Category Description</b></TableCell>
                                        <TableCell align="center"><b>Icon</b></TableCell>
                                        <TableCell align="center"><b>Parent</b></TableCell>
                                        <TableCell align="center"><b>Edit</b></TableCell>
                                        <TableCell align="center"><b>Delete</b></TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {category.length > 0 && category.map((row) => (
                                        <TableRow key={row.id}>
                                            <TableCell component="th" scope="row">{row.category_name}</TableCell>
                                            <TableCell align="center">{row.category_description}</TableCell>
                                            <TableCell align="center">{row.icon}</TableCell>
                                            <TableCell align="center">{getParentCategoryName(row.parent_id)}</TableCell>
                                            <TableCell align="center">
                                                <Link to={`/admin/editcategories/${row.id}`} className={classes.removeLink}>
                                                    <Button size="small" variant="contained" color="primary">Edit</Button></Link>
                                            </TableCell>
                                            <TableCell align="center">
                                                <Button size="small" variant="contained" color="secondary"
                                                    onClick={() => deleteCategoryID(row.id)}>Remove</Button>
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