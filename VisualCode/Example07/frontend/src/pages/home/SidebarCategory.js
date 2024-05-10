import React, { Component } from 'react'
import { closeOutline } from 'ionicons/icons';
import { IonIcon } from '@ionic/react';
import { addOutline } from 'ionicons/icons';
import { removeOutline } from 'ionicons/icons';
import axios from "axios";
// import { Link } from 'react-router-dom'
class SidebarCategory extends Component {


    constructor(props) {
        super(props);
        this.state = {
            categories: [],

            openSubMenus: []

        };
    }



    toggleSubMenu = (categoryId) => {
        this.setState(prevState => ({
            openSubMenus: prevState.openSubMenus.includes(categoryId)
                ? prevState.openSubMenus.filter(id => id !== categoryId) // Nếu categoryId đã có trong openSubMenus, loại bỏ nó ra khỏi mảng
                : [...prevState.openSubMenus, categoryId] // Nếu categoryId chưa có trong openSubMenus, thêm nó vào mảng
        }));
    }

    componentDidMount() {
        axios.get("http://localhost:5019/api/Category")
            .then((response) => {
                this.setState({ categories: response.data });
            })
            .catch((error) => {
                console.error('Error fetching data:', error);
            });
    }

    render() {
        const { categories } = this.state;
        return (

            <div className="sidebar-category">
                <div className="sidebar-top">
                    <h2 className="sidebar-title">Category</h2>
                    <button className="sidebar-close-btn" data-mobile-menu-close-btn="">
                        <IonIcon icon={closeOutline} /> {/* Sử dụng icon "logo-facebook" */}
                    </button>
                </div>
                <ul className="sidebar-menu-category-list">

                    {/* ------------------------------- */}

                    {categories.map((category) => (
                        <li className="sidebar-menu-category" key={category.id}>
                            {/* Kiểm tra nếu parent_id là null (menu cha), thì sử dụng toggleSubMenu */}
                            {category.parent_id === null ? (
                                <div>
                                    <button className="sidebar-accordion-menu" onClick={() => this.toggleSubMenu(category.id)} data-accordion-btn="">
                                        <div className="menu-title-flex">
                                            <img
                                                src={"./assets/images/icons/"+category.icon}
                                                alt={category.category_name}
                                                width={20}
                                                height={20}
                                                className="menu-title-img"
                                            />
                                            <p className="menu-title">{category.category_name}</p>
                                        </div>
                                        <div>
                                            <IonIcon
                                                icon={this.state.openSubMenus.includes(category.id) ? removeOutline : addOutline}
                                                className="md hydrated"
                                                role="img"
                                                aria-label={this.state.openSubMenus.includes(category.id) ? 'remove outline' : 'add outline'}
                                            />
                                        </div>
                                    </button>

                                    <div className={`sidebar-submenu-category-list ${this.state.openSubMenus.includes(category.id) ? 'open' : ''}`}>
                                        {categories
                                            .filter(subcategory => subcategory.parent_id === category.id)
                                            .map(subcategory => (
                                                <a href="#" className="sidebar-submenu-title" style={{ marginLeft: 20 }} key={subcategory.id}>
                                                    <p className="product-name">{subcategory.category_name}</p>

                                                </a>
                                            ))
                                        }
                                    </div>
                                </div>
                            ) : null}
                        </li>
                    ))}
                </ul>
            </div>
        )
    }
}
export default SidebarCategory;