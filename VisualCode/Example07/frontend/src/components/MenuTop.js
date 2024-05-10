import React from 'react';
import { Link } from 'react-router-dom'
import { makeStyles } from '@mui/styles';
import { AppBar, Toolbar, Typography, IconButton } from '@mui/material';
import MenuIcon from '@mui/icons-material/Menu';
import MenuItem from '@mui/material/MenuItem';
import Menu from '@mui/material/Menu';
import MoreVertIcon from '@mui/icons-material/Menu';

const useStyles = makeStyles((theme) => ({
    root: {
        width: '100%',
        flexGrow: 1,
    },
    title: {
        flexGrow: 1
    },
    linkTo: {
        textDecoration: 'none',
        color: '#000'
    },

    linkHome: {
        textDecoration: 'none',
        color: '#fff'
    }
}));
export default function MenuTop() {
    const classes = useStyles();
    const [anchorEl, setAnchorEl] = React.useState(null);
    const isMenuOpen = Boolean(anchorEl);
    const handleProfileMenuOpen = (event) => {
        setAnchorEl(event.currentTarget);
    };
    const handleMenuClose = () => {
        setAnchorEl(null);
    };
    const menuId = 'primary-search-account-menu';
    const renderMenu = (
        <Menu
            anchorEl={anchorEl}
            anchorOrigin={{ vertical: 'top', horizontal: 'right' }}
            id={menuId}
            keepMounted
            transformOrigin={{ vertical: 'top', horizontal: 'right' }}
            open={isMenuOpen} y
            onClose={handleMenuClose}
        >
            <MenuItem onClick={handleMenuClose}><Link to="/admin/addproducts" className={classes.linkTo}>Add Product</Link></MenuItem>
            <MenuItem onClick={handleMenuClose}><Link to="/admin/categories" className={classes.linkTo}>Category</Link></MenuItem>
            <MenuItem onClick={handleMenuClose}><Link to="/admin/addcategories" className={classes.linkTo}>Add Category</Link></MenuItem>
            <MenuItem onClick={handleMenuClose}><Link to="/admin/tags" className={classes.linkTo}>Tag</Link></MenuItem>
            <MenuItem onClick={handleMenuClose}><Link to="/admin/addtags" className={classes.linkTo}>Add Tag</Link></MenuItem>
            <MenuItem onClick={handleMenuClose}><Link to="/admin/galleries" className={classes.linkTo}>Gallery</Link></MenuItem>
            <MenuItem onClick={handleMenuClose}><Link to="/admin/addgalleries" className={classes.linkTo}>Add Gallery</Link></MenuItem>
            <MenuItem onClick={handleMenuClose}><Link to="/admin/productcategories" className={classes.linkTo}>Product Category</Link></MenuItem>
            <MenuItem onClick={handleMenuClose}><Link to="/admin/addproductcategories" className={classes.linkTo}>Add Product Category</Link></MenuItem>
            <MenuItem onClick={handleMenuClose}><Link to="/admin/producttags" className={classes.linkTo}>Product Tag</Link></MenuItem>
            <MenuItem onClick={handleMenuClose}><Link to="/admin/addproducttags" className={classes.linkTo}>Add Product Tag</Link></MenuItem>
        </Menu>
    );
    return (
        <div className={classes.root}>
            {renderMenu}
            <AppBar position="static" color="primary">
                <Toolbar>
                    <IconButton edge="start" color="inherit" aria-label="menu">
                        <MenuIcon />
                    </IconButton>
                    <Typography variant="h6" className={classes.title}>
                        <Link to="/admin" className={classes.linkHome}>Mac Quoc Huy</Link>
                    </Typography>
                    <IconButton edge="end" color="inherit" aria-label="MoreVert" aria-controls={menuId}
                        aria-haspopup="true"
                        onClick={handleProfileMenuOpen}>
                        <MoreVertIcon />
                    </IconButton>
                </Toolbar>
            </AppBar>
            {renderMenu}
        </div>
    )
}
