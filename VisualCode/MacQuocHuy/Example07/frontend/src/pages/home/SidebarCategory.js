// import React, { useEffect, useState } from 'react'
// import { Link } from "react-router-dom"


// import axios from "axios"
// const SidebarCategory = () => {
//     const [categories, setCategories] = useState([]);

//     useEffect(() => {
//         axios.get("http://localhost:5019/api/Category").then((response) => {
//             setCategories((data) => {
//                 return response.data;
//             });
//         });
//     }, []);
//     return (
//         <div className="sidebar-category">

//             <div className="sidebar-top">
//                 <h2 className="sidebar-title">Category</h2>

//                 <button className="sidebar-close-btn" data-mobile-menu-close-btn>
//                     <ion-icon name="close-outline"></ion-icon>
//                 </button>
//             </div>

//             <ul className="sidebar-menu-category-list">

//                 {categories.map((cat) => {
//                     return (
//                         <li className="sidebar-menu-category">

//                             <button className="sidebar-accordion-menu" data-accordion-btn>

//                                 <div className="menu-title-flex">
//                                     <img src={"./assets/images/icons/"+cat.icon} alt="clothes" width="20" height="20"
//                                         className="menu-title-img" />

//                                     <p className="menu-title">{cat.category_name}</p>
//                                 </div>

//                                 <div>
//                                     <ion-icon name="add-outline" className="add-icon"></ion-icon>
//                                     <ion-icon name="remove-outline" className="remove-icon"></ion-icon>
//                                 </div>

//                             </button>

//                             <ul className="sidebar-submenu-category-list" data-accordion>

//                                 <li className="sidebar-submenu-category">
//                                     <Link to="#" className="sidebar-submenu-title">
//                                         <p className="product-name">Shirt</p>
//                                         <data value="300" className="stock" title="Available Stock">300</data>
//                                     </Link>
//                                 </li>

//                                 <li className="sidebar-submenu-category">
//                                     <Link to="#" className="sidebar-submenu-title">
//                                         <p className="product-name">shorts & jeans</p>
//                                         <data value="60" className="stock" title="Available Stock">60</data>
//                                     </Link>
//                                 </li>

//                                 <li className="sidebar-submenu-category">
//                                     <Link to="#" className="sidebar-submenu-title">
//                                         <p className="product-name">jacket</p>
//                                         <data value="50" className="stock" title="Available Stock">50</data>
//                                     </Link>
//                                 </li>

//                                 <li className="sidebar-submenu-category">
//                                     <Link to="#" className="sidebar-submenu-title">
//                                         <p className="product-name">dress & frock</p>
//                                         <data value="87" className="stock" title="Available Stock">87</data>
//                                     </Link>
//                                 </li>

//                             </ul>

//                         </li>
//                     );
//                 })}

//                 {/* <li className="sidebar-menu-category">

//                     <button className="sidebar-accordion-menu" data-accordion-btn>

//                         <div className="menu-title-flex">
//                             <img src="./assets/images/icons/shoes.svg" alt="footwear" className="menu-title-img" width="20"
//                                 height="20" />

//                             <p className="menu-title">Footwear</p>
//                         </div>

//                         <div>
//                             <ion-icon name="add-outline" className="add-icon"></ion-icon>
//                             <ion-icon name="remove-outline" className="remove-icon"></ion-icon>
//                         </div>

//                     </button>

//                     <ul className="sidebar-submenu-category-list" data-accordion>

//                         <li className="sidebar-submenu-category">
//                             <Link to="#" className="sidebar-submenu-title">
//                                 <p className="product-name">Sports</p>
//                                 <data value="45" className="stock" title="Available Stock">45</data>
//                             </Link>
//                         </li>

//                         <li className="sidebar-submenu-category">
//                             <Link to="#" className="sidebar-submenu-title">
//                                 <p className="product-name">Formal</p>
//                                 <data value="75" className="stock" title="Available Stock">75</data>
//                             </Link>
//                         </li>

//                         <li className="sidebar-submenu-category">
//                             <Link to="#" className="sidebar-submenu-title">
//                                 <p className="product-name">Casual</p>
//                                 <data value="35" className="stock" title="Available Stock">35</data>
//                             </Link>
//                         </li>

//                         <li className="sidebar-submenu-category">
//                             <Link to="#" className="sidebar-submenu-title">
//                                 <p className="product-name">Safety Shoes</p>
//                                 <data value="26" className="stock" title="Available Stock">26</data>
//                             </Link>
//                         </li>

//                     </ul>

//                 </li>

//                 <li className="sidebar-menu-category">

//                     <button className="sidebar-accordion-menu" data-accordion-btn>

//                         <div className="menu-title-flex">
//                             <img src="./assets/images/icons/jewelry.svg" alt="clothes" className="menu-title-img" width="20"
//                                 height="20" />

//                             <p className="menu-title">Jewelry</p>
//                         </div>

//                         <div>
//                             <ion-icon name="add-outline" className="add-icon"></ion-icon>
//                             <ion-icon name="remove-outline" className="remove-icon"></ion-icon>
//                         </div>

//                     </button>

//                     <ul className="sidebar-submenu-category-list" data-accordion>

//                         <li className="sidebar-submenu-category">
//                             <Link to="#" className="sidebar-submenu-title">
//                                 <p className="product-name">Earrings</p>
//                                 <data value="46" className="stock" title="Available Stock">46</data>
//                             </Link>
//                         </li>

//                         <li className="sidebar-submenu-category">
//                             <Link to="#" className="sidebar-submenu-title">
//                                 <p className="product-name">Couple Rings</p>
//                                 <data value="73" className="stock" title="Available Stock">73</data>
//                             </Link>
//                         </li>

//                         <li className="sidebar-submenu-category">
//                             <Link to="#" className="sidebar-submenu-title">
//                                 <p className="product-name">Necklace</p>
//                                 <data value="61" className="stock" title="Available Stock">61</data>
//                             </Link>
//                         </li>

//                     </ul>

//                 </li>

//                 <li className="sidebar-menu-category">

//                     <button className="sidebar-accordion-menu" data-accordion-btn>

//                         <div className="menu-title-flex">
//                             <img src="./assets/images/icons/perfume.svg" alt="perfume" className="menu-title-img" width="20"
//                                 height="20" />

//                             <p className="menu-title">Perfume</p>
//                         </div>

//                         <div>
//                             <ion-icon name="add-outline" className="add-icon"></ion-icon>
//                             <ion-icon name="remove-outline" className="remove-icon"></ion-icon>
//                         </div>

//                     </button>

//                     <ul className="sidebar-submenu-category-list" data-accordion>

//                         <li className="sidebar-submenu-category">
//                             <Link to="#" className="sidebar-submenu-title">
//                                 <p className="product-name">Clothes Perfume</p>
//                                 <data value="12" className="stock" title="Available Stock">12 pcs</data>
//                             </Link>
//                         </li>

//                         <li className="sidebar-submenu-category">
//                             <Link to="#" className="sidebar-submenu-title">
//                                 <p className="product-name">Deodorant</p>
//                                 <data value="60" className="stock" title="Available Stock">60 pcs</data>
//                             </Link>
//                         </li>

//                         <li className="sidebar-submenu-category">
//                             <Link to="#" className="sidebar-submenu-title">
//                                 <p className="product-name">jacket</p>
//                                 <data value="50" className="stock" title="Available Stock">50 pcs</data>
//                             </Link>
//                         </li>

//                         <li className="sidebar-submenu-category">
//                             <Link to="#" className="sidebar-submenu-title">
//                                 <p className="product-name">dress & frock</p>
//                                 <data value="87" className="stock" title="Available Stock">87 pcs</data>
//                             </Link>
//                         </li>

//                     </ul>

//                 </li>

//                 <li className="sidebar-menu-category">

//                     <button className="sidebar-accordion-menu" data-accordion-btn>

//                         <div className="menu-title-flex">
//                             <img src="./assets/images/icons/cosmetics.svg" alt="cosmetics" className="menu-title-img" width="20"
//                                 height="20" />

//                             <p className="menu-title">Cosmetics</p>
//                         </div>

//                         <div>
//                             <ion-icon name="add-outline" className="add-icon"></ion-icon>
//                             <ion-icon name="remove-outline" className="remove-icon"></ion-icon>
//                         </div>

//                     </button>

//                     <ul className="sidebar-submenu-category-list" data-accordion>

//                         <li className="sidebar-submenu-category">
//                             <Link to="#" className="sidebar-submenu-title">
//                                 <p className="product-name">Shampoo</p>
//                                 <data value="68" className="stock" title="Available Stock">68</data>
//                             </Link>
//                         </li>

//                         <li className="sidebar-submenu-category">
//                             <Link to="#" className="sidebar-submenu-title">
//                                 <p className="product-name">Sunscreen</p>
//                                 <data value="46" className="stock" title="Available Stock">46</data>
//                             </Link>
//                         </li>

//                         <li className="sidebar-submenu-category">
//                             <Link to="#" className="sidebar-submenu-title">
//                                 <p className="product-name">Body Wash</p>
//                                 <data value="79" className="stock" title="Available Stock">79</data>
//                             </Link>
//                         </li>

//                         <li className="sidebar-submenu-category">
//                             <Link to="#" className="sidebar-submenu-title">
//                                 <p className="product-name">Makeup Kit</p>
//                                 <data value="23" className="stock" title="Available Stock">23</data>
//                             </Link>
//                         </li>

//                     </ul>

//                 </li>

//                 <li className="sidebar-menu-category">

//                     <button className="sidebar-accordion-menu" data-accordion-btn>

//                         <div className="menu-title-flex">
//                             <img src="./assets/images/icons/glasses.svg" alt="glasses" className="menu-title-img" width="20"
//                                 height="20" />

//                             <p className="menu-title">Glasses</p>
//                         </div>

//                         <div>
//                             <ion-icon name="add-outline" className="add-icon"></ion-icon>
//                             <ion-icon name="remove-outline" className="remove-icon"></ion-icon>
//                         </div>

//                     </button>

//                     <ul className="sidebar-submenu-category-list" data-accordion>

//                         <li className="sidebar-submenu-category">
//                             <Link to="#" className="sidebar-submenu-title">
//                                 <p className="product-name">Sunglasses</p>
//                                 <data value="50" className="stock" title="Available Stock">50</data>
//                             </Link>
//                         </li>

//                         <li className="sidebar-submenu-category">
//                             <Link to="#" className="sidebar-submenu-title">
//                                 <p className="product-name">Lenses</p>
//                                 <data value="48" className="stock" title="Available Stock">48</data>
//                             </Link>
//                         </li>

//                     </ul>

//                 </li>

//                 <li className="sidebar-menu-category">

//                     <button className="sidebar-accordion-menu" data-accordion-btn>

//                         <div className="menu-title-flex">
//                             <img src="./assets/images/icons/bag.svg" alt="bags" className="menu-title-img" width="20" height="20" />

//                             <p className="menu-title">Bags</p>
//                         </div>

//                         <div>
//                             <ion-icon name="add-outline" className="add-icon"></ion-icon>
//                             <ion-icon name="remove-outline" className="remove-icon"></ion-icon>
//                         </div>

//                     </button>

//                     <ul className="sidebar-submenu-category-list" data-accordion>

//                         <li className="sidebar-submenu-category">
//                             <Link to="#" className="sidebar-submenu-title">
//                                 <p className="product-name">Shopping Bag</p>
//                                 <data value="62" className="stock" title="Available Stock">62</data>
//                             </Link>
//                         </li>

//                         <li className="sidebar-submenu-category">
//                             <Link to="#" className="sidebar-submenu-title">
//                                 <p className="product-name">Gym Backpack</p>
//                                 <data value="35" className="stock" title="Available Stock">35</data>
//                             </Link>
//                         </li>

//                         <li className="sidebar-submenu-category">
//                             <Link to="#" className="sidebar-submenu-title">
//                                 <p className="product-name">Purse</p>
//                                 <data value="80" className="stock" title="Available Stock">80</data>
//                             </Link>
//                         </li>

//                         <li className="sidebar-submenu-category">
//                             <Link to="#" className="sidebar-submenu-title">
//                                 <p className="product-name">Wallet</p>
//                                 <data value="75" className="stock" title="Available Stock">75</data>
//                             </Link>
//                         </li>

//                     </ul>

//                 </li> */}

//             </ul>

//         </div>
//     );
// }
// export default SidebarCategory;



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