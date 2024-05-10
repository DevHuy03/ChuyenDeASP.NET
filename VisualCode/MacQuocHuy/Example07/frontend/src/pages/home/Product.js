import React, { useEffect, useState } from 'react'
import SidebarCategory from './SidebarCategory';
import { IonIcon } from '@ionic/react';
import axios from "axios"
import { heartOutline, eyeOutline, repeatOutline, bagAddOutline, star, starOutline } from 'ionicons/icons';


const Product = () => {
    const [products, setProducts] = useState([]);
    const [productTags, setProductTags] = useState([]);
    const [gallery, setGallery] = useState([]);
    const [tagNewArrivals, setTagNewArrivals] = useState([]);
    const [tagTrending, setTagTrending] = useState([]);
    const [tagTopRated, setTagTopRated] = useState([]);
    const [tagDealOfTheDay, setDealOfTheDay] = useState([]);
    const [tagNewProducts, setTagNewProducts] = useState([]);
    const [tagBestSelles, setTBestSelles] = useState([]);
    const [dataLoaded, setDataLoaded] = useState(false);
    const [category, setCategory] = useState([]);
    const [productCategory, setProductCategory] = useState([]);

    useEffect(() => {
        axios.get("http://localhost:5019/api/Product").then((response) => {
            setProducts((data) => {
                return response.data;
            });
            setDataLoaded(true);
        });
    }, []);

    useEffect(() => {
        axios
            .get("http://localhost:5019/api/Tag")
            .then((response) => {
                const newTags = response.data.filter(
                    (tag) => tag.tag_name === "New Arrivals"
                );
                const trendding = response.data.filter(
                    (tag) => tag.tag_name === "Trending"
                );
                const topRated = response.data.filter(
                    (tag) => tag.tag_name === "Top Rated"
                );
                const newProduct = response.data.filter(
                    (tag) => tag.tag_name === "New Products"
                );
                const bestSelles = response.data.filter(
                    (tag) => tag.tag_name === "BEST SELLERS"
                );
                const dealOfTheDay = response.data.filter(
                    (tag) => tag.tag_name === "Deal of the day"
                );
                setTagNewArrivals(newTags);
                setTagTrending(trendding);
                setTagTopRated(topRated);
                setTagNewProducts(newProduct);
                setTBestSelles(bestSelles);
                setDealOfTheDay(dealOfTheDay);

                setDataLoaded(true);
            })
            .catch((error) => {
                console.error("Error fetching tag data:", error);
            });
    }, []);

    useEffect(() => {
        axios.get("http://localhost:5019/api/Category").then((response) => {
            setCategory((data) => {
                return response.data;
            });
            setDataLoaded(true);
        });
    }, []);

    useEffect(() => {
        axios.get("http://localhost:5019/api/Product_Category").then((response) => {
            setProductCategory((data) => {
                return response.data;
            });
            setDataLoaded(true);
        });
    }, []);

    useEffect(() => {
        axios.get("http://localhost:5019/api/Product_Tag").then((response) => {
            setProductTags((data) => {
                return response.data;
            });
            setDataLoaded(true);
        });
    }, []);

    useEffect(() => {
        axios.get("http://localhost:5019/api/Gallery").then((response) => {
            setGallery((data) => {
                return response.data;
            });
            setDataLoaded(true);
        });
    }, []);

    const getNewArrivalProducts = () => {
        const newArrivalProductIds = productTags
            .filter((productTag) =>
                tagNewArrivals.some((tag) => tag.id === productTag.tag_id)
            )
            .map((productTag) => productTag.product_id);

        return products.filter((item) => newArrivalProductIds.includes(item.id));
    };
    const getTrenndingProducts = () => {
        const newTrenndingProductIds = productTags
            .filter((productTag) =>
                tagTrending.some((tag) => tag.id === productTag.tag_id)
            )
            .map((productTag) => productTag.product_id);
        return products.filter((item) => newTrenndingProductIds.includes(item.id));
    };
    const getTopRatedProducts = () => {
        const newTopRatedProductIds = productTags
            .filter((productTag) =>
                tagTopRated.some((tag) => tag.id === productTag.tag_id)
            )
            .map((productTag) => productTag.product_id);

        return products.filter((item) => newTopRatedProductIds.includes(item.id));
    };
    const getNewProducts = () => {
        const newProductIds = productTags
            .filter((productTag) =>
                tagNewProducts.some((tag) => tag.id === productTag.tag_id)
            )
            .map((productTag) => productTag.product_id);

        return products.filter((item) => newProductIds.includes(item.id));
    };
    const getBestSellers = () => {
        const newBestSellersIds = productTags
            .filter((productTag) =>
                tagBestSelles.some((tag) => tag.id === productTag.tag_id)
            )
            .map((productTag) => productTag.product_id);

        return products.filter((item) => newBestSellersIds.includes(item.id));
    };
    const getDealOfTheDay = () => {
        const newDealOfTheDaysIds = productTags
            .filter((productTag) =>
                tagDealOfTheDay.some((tag) => tag.id === productTag.tag_id)
            )
            .map((productTag) => productTag.product_id);

        return products.filter((item) => newDealOfTheDaysIds.includes(item.id));
    };
    const getCategoryName = (productId) => {
        // Lấy ra productCategory có productId trùng với productId được truyền vào
        const productCategoryItem = productCategory.find(
            (item) => item.product_id === productId
        );
        if (productCategoryItem) {
            // Lấy ra categoryName từ category có id tương ứng trong productCategory
            const categoryId = productCategoryItem.category_id;
            const categoryItem = category.find((item) => item.id === categoryId);
            if (categoryItem) {
                return categoryItem.category_name;
            }
        }
        return ""; // Trả về rỗng nếu không tìm thấy
    };
    const getProductImages = (productId) => {
        const productImages = gallery.filter(
            (image) => image.product_id === productId
        );
        return productImages.length > 0 ? [productImages[0]] : [];
        // Trả về mảng chứa hình ảnh đầu tiên hoặc mảng rỗng nếu không có hình ảnh
    };

    const getProductNewImages = (productId) => {
        const productImages = gallery.filter(
            (image) => image.product_id === productId
        );
        return productImages.slice(0, 2); // Chỉ lấy hai hình ảnh đầu tiên
    };

    return (
        <div className="product-container">

            <div className="container">

                {/* SIDEBAR */}

                <div className="sidebar  has-scrollbar" data-mobile-menu>

                    <SidebarCategory />

                    <div className="product-showcase">

                        <h3 className="showcase-heading">best sellers</h3>

                        <div className="showcase-wrapper">

                            <div className="showcase-container">
                                {dataLoaded && getBestSellers()
                                    .map((pr, index) => (
                                        <div className="showcase" key={index}>

                                            <a href="#" className="showcase-img-box">
                                                <img src={`./assets/images/products/${getProductImages(pr.id)[0].image}`} alt="baby fabric shoes" width="75" height="75"
                                                    className="showcase-img" />
                                            </a>

                                            <div className="showcase-content">

                                                <a href="#">
                                                    <h4 className="showcase-title">{pr.product_name}</h4>
                                                </a>

                                                <div className="showcase-rating">
                                                    <IonIcon icon={star} />
                                                    <IonIcon icon={star} />
                                                    <IonIcon icon={star} />
                                                    <IonIcon icon={star} />
                                                    <IonIcon icon={star} />
                                                </div>

                                                <div className="price-box">
                                                    <del>${pr.buying_price}.00</del>
                                                    <p className="price">${pr.sale_price}.00</p>
                                                </div>

                                            </div>

                                        </div>
                                    ))}
                            </div>

                        </div>

                    </div>

                </div>



                <div className="product-box">

                    {/* PRODUCT MINIMAL */}

                    <div className="product-minimal">

                        <div class="product-showcase">
                            <h2 class="title">New Arrivals</h2>

                            <div class="showcase-wrapper has-scrollbar">
                                <div class="showcase-container">
                                    {dataLoaded &&
                                        getNewArrivalProducts()
                                            .map((item, index) => (
                                                <div className="showcase" key={index}>
                                                    <a href="#" className="showcase-img-box">

                                                        <img
                                                            key={index}
                                                            src={`./assets/images/products/${getProductImages(item.id)[0].image
                                                                }`}
                                                            alt={`Product Image ${index + 1}`}
                                                            class="showcase-img"
                                                            width="70"
                                                        />

                                                    </a>
                                                    <div className="showcase-content">
                                                        <a href="#">
                                                            <h4 className="showcase-title">{item.product_name}</h4>
                                                        </a>
                                                        <a href="#" className="showcase-category">
                                                            {getCategoryName(item.id)}
                                                        </a>
                                                        <div className="price-box">
                                                            <p className="price">${item.sale_price}.00</p>
                                                            <del>${item.buying_price}.00</del>
                                                        </div>
                                                    </div>
                                                </div>
                                            ))
                                            .slice(0, 4)}
                                </div>
                                <div class="showcase-container">
                                    {dataLoaded &&
                                        getNewArrivalProducts()
                                            .slice(4)
                                            .map((item, index) => (
                                                <div className="showcase" key={index}>
                                                    <a href="#" className="showcase-img-box">
                                                        <img
                                                            src={`./assets/images/products/${getProductImages(item.id)[0].image
                                                                }`}
                                                            alt={`Product Image ${index + 1}`}
                                                            className="showcase-img"
                                                            width="70"
                                                        />
                                                    </a>
                                                    <div className="showcase-content">
                                                        <a href="#">
                                                            <h4 className="showcase-title">{item.product_name}</h4>
                                                        </a>
                                                        <a href="#" className="showcase-category">
                                                            {getCategoryName(item.id)}
                                                        </a>
                                                        <div className="price-box">
                                                            <p className="price">${item.sale_price}.00</p>
                                                            <del>${item.buying_price}.00</del>
                                                        </div>
                                                    </div>
                                                </div>
                                            ))}
                                </div>
                            </div>
                        </div>

                        <div className="product-showcase">

                            <h2 className="title">Trending</h2>

                            <div class="showcase-wrapper  has-scrollbar">
                                <div class="showcase-container">
                                    {dataLoaded &&
                                        getTrenndingProducts()
                                            .map((item, index) => (
                                                <div className="showcase" key={index}>
                                                    <a href="#" className="showcase-img-box">
                                                        <img
                                                            key={index}
                                                            src={`./assets/images/products/${getProductImages(item.id)[0].image
                                                                }`}
                                                            alt={`Product Image ${index + 1}`}
                                                            class="showcase-img"
                                                            width="70"
                                                        />
                                                    </a>
                                                    <div className="showcase-content">
                                                        <a href="#">
                                                            <h4 className="showcase-title">{item.product_name}</h4>
                                                        </a>
                                                        <a href="#" className="showcase-category">
                                                            {getCategoryName(item.id)}
                                                        </a>
                                                        <div className="price-box">
                                                            <p className="price">${item.sale_price}.00</p>
                                                            <del>${item.buying_price}.00</del>
                                                        </div>
                                                    </div>
                                                </div>
                                            ))
                                            .slice(0, 4)}
                                </div>
                                <div class="showcase-container">
                                    {dataLoaded &&
                                        getTrenndingProducts()
                                            .slice(4)
                                            .map((item, index) => (
                                                <div className="showcase" key={index}>
                                                    <a href="#" className="showcase-img-box">
                                                        <img
                                                            src={`./assets/images/products/${getProductImages(item.id)[0].image
                                                                }`}
                                                            alt={`Product Image ${index + 1}`}
                                                            className="showcase-img"
                                                            width="70"
                                                        />
                                                    </a>
                                                    <div className="showcase-content">
                                                        <a href="#">
                                                            <h4 className="showcase-title">{item.product_name}</h4>
                                                        </a>
                                                        <a href="#" className="showcase-category">
                                                            {getCategoryName(item.id)}
                                                        </a>
                                                        <div className="price-box">
                                                            <p className="price">${item.sale_price}.00</p>
                                                            <del>${item.buying_price}.00</del>
                                                        </div>
                                                    </div>
                                                </div>
                                            ))}
                                </div>
                            </div>

                        </div>

                        <div className="product-showcase">

                            <h2 className="title">Top Rated</h2>

                            <div class="showcase-wrapper  has-scrollbar">
                                <div class="showcase-container">
                                    {dataLoaded &&
                                        getTopRatedProducts()
                                            .map((item, index) => (
                                                <div className="showcase" key={index}>
                                                    <a href="#" className="showcase-img-box">
                                                        <img
                                                            key={index}
                                                            src={`./assets/images/products/${getProductImages(item.id)[0].image
                                                                }`}
                                                            alt={`Product Image ${index + 1}`}
                                                            class="showcase-img"
                                                            width="70"
                                                        />
                                                    </a>
                                                    <div className="showcase-content">
                                                        <a href="#">
                                                            <h4 className="showcase-title">{item.product_name}</h4>
                                                        </a>
                                                        <a href="#" className="showcase-category">
                                                            {getCategoryName(item.id)}
                                                        </a>
                                                        <div className="price-box">
                                                            <p className="price">${item.sale_price}.00</p>
                                                            <del>${item.buying_price}.00</del>
                                                        </div>
                                                    </div>
                                                </div>
                                            ))
                                            .slice(0, 4)}
                                </div>
                                <div class="showcase-container">
                                    {dataLoaded &&
                                        getTopRatedProducts()
                                            .slice(4)
                                            .map((item, index) => (
                                                <div className="showcase" key={index}>
                                                    <a href="#" className="showcase-img-box">
                                                        <img
                                                            src={`./assets/images/products/${getProductImages(item.id)[0].image
                                                                }`}
                                                            alt={`Product Image ${index + 1}`}
                                                            className="showcase-img"
                                                            width="70"
                                                        />
                                                    </a>
                                                    <div className="showcase-content">
                                                        <a href="#">
                                                            <h4 className="showcase-title">{item.product_name}</h4>
                                                        </a>
                                                        <a href="#" className="showcase-category">
                                                            {getCategoryName(item.id)}
                                                        </a>
                                                        <div className="price-box">
                                                            <p className="price">${item.sale_price}.00</p>
                                                            <del>${item.buying_price}.00</del>
                                                        </div>
                                                    </div>
                                                </div>
                                            ))}
                                </div>
                            </div>

                        </div>

                    </div>



                    {/* PRODUCT FEATURED */}

                    <div className="product-featured">

                        <h2 className="title">Deal of the day</h2>

                        <div className="showcase-wrapper has-scrollbar" >

                            <div className="showcase-container" >
                                {dataLoaded && getDealOfTheDay()
                                    .map((pr, index) => (
                                        <div className="showcase" key={index}>

                                            <div className="showcase-banner">
                                                <img
                                                    src={`./assets/images/products/${getProductImages(pr.id)[0].image
                                                        }`}
                                                    alt="shampoo, conditioner & facewash packs"
                                                    className="showcase-img" />
                                            </div>

                                            <div className="showcase-content">

                                                <div className="showcase-rating">
                                                    <IonIcon icon={star} />
                                                    <IonIcon icon={star} />
                                                    <IonIcon icon={star} />
                                                    <IonIcon icon={starOutline} />
                                                    <IonIcon icon={starOutline} />
                                                </div>

                                                <a href="#">
                                                    <h3 className="showcase-title">{pr.product_name}</h3>
                                                </a>

                                                <p className="showcase-desc">
                                                    {pr.product_title}
                                                </p>

                                                <div className="price-box">
                                                    <p className="price">${pr.sale_price}.00</p>

                                                    <del>${pr.buying_price}.00</del>
                                                </div>

                                                <button className="add-cart-btn">add to cart</button>

                                                <div className="showcase-status">
                                                    <div className="wrapper">
                                                        <p>
                                                            already sold: <b>20</b>
                                                        </p>

                                                        <p>
                                                            available: <b>40</b>
                                                        </p>
                                                    </div>

                                                    <div className="showcase-status-bar"></div>
                                                </div>

                                                <div className="countdown-box">

                                                    <p className="countdown-desc">
                                                        Hurry Up! Offer ends in:
                                                    </p>

                                                    <div className="countdown">

                                                        <div className="countdown-content">

                                                            <p className="display-number">360</p>

                                                            <p className="display-text">Days</p>

                                                        </div>

                                                        <div className="countdown-content">
                                                            <p className="display-number">24</p>
                                                            <p className="display-text">Hours</p>
                                                        </div>

                                                        <div className="countdown-content">
                                                            <p className="display-number">59</p>
                                                            <p className="display-text">Min</p>
                                                        </div>

                                                        <div className="countdown-content">
                                                            <p className="display-number">00</p>
                                                            <p className="display-text">Sec</p>
                                                        </div>

                                                    </div>

                                                </div>

                                            </div>

                                        </div>
                                    )).slice(0, 1)}
                            </div>
                            <div className="showcase-container" >
                                {dataLoaded && getDealOfTheDay().slice(1)
                                    .map((pr, index) => (
                                        <div className="showcase" key={index}>

                                            <div className="showcase-banner">
                                                <img src={`./assets/images/products/${getProductImages(pr.id)[0].image}`} alt="shampoo, conditioner & facewash packs" className="showcase-img" />
                                            </div>

                                            <div className="showcase-content">

                                                <div className="showcase-rating">
                                                    <IonIcon icon={star} />
                                                    <IonIcon icon={star} />
                                                    <IonIcon icon={star} />
                                                    <IonIcon icon={starOutline} />
                                                    <IonIcon icon={starOutline} />
                                                </div>

                                                <a href="#">
                                                    <h3 className="showcase-title">{pr.product_name}</h3>
                                                </a>

                                                <p className="showcase-desc">
                                                    {pr.product_title}
                                                </p>

                                                <div className="price-box">
                                                    <p className="price">${pr.sale_price}.00</p>

                                                    <del>${pr.buying_price}.00</del>
                                                </div>

                                                <button className="add-cart-btn">add to cart</button>

                                                <div className="showcase-status">
                                                    <div className="wrapper">
                                                        <p>
                                                            already sold: <b>20</b>
                                                        </p>

                                                        <p>
                                                            available: <b>40</b>
                                                        </p>
                                                    </div>

                                                    <div className="showcase-status-bar"></div>
                                                </div>

                                                <div className="countdown-box">

                                                    <p className="countdown-desc">
                                                        Hurry Up! Offer ends in:
                                                    </p>

                                                    <div className="countdown">

                                                        <div className="countdown-content">

                                                            <p className="display-number">360</p>

                                                            <p className="display-text">Days</p>

                                                        </div>

                                                        <div className="countdown-content">
                                                            <p className="display-number">24</p>
                                                            <p className="display-text">Hours</p>
                                                        </div>

                                                        <div className="countdown-content">
                                                            <p className="display-number">59</p>
                                                            <p className="display-text">Min</p>
                                                        </div>

                                                        <div className="countdown-content">
                                                            <p className="display-number">00</p>
                                                            <p className="display-text">Sec</p>
                                                        </div>

                                                    </div>

                                                </div>

                                            </div>

                                        </div>
                                    ))}
                            </div>
                        </div>

                    </div>




                    {/* PRODUCT GRID */}


                    <div className="product-main">

                        <h2 className="title">New Products</h2>

                        <div className="product-grid">
                            {dataLoaded && getNewProducts()
                                .map((pr, index) => (
                                    <div className="showcase" key={pr.id}>

                                        <div className="showcase-banner" key={index}>


                                            {getProductNewImages(pr.id).map((image, imageIndex) => (
                                                <img
                                                    key={imageIndex}
                                                    src={`./assets/images/products//${image.image}`}
                                                    alt="Error"
                                                    width="300"
                                                    className={
                                                        imageIndex === 0
                                                            ? "product-img default"
                                                            : "product-img hover"
                                                    }
                                                />
                                            ))}
                                            {/* <img src={"./assets/images/products/" + pr.compare_price} alt="Mens Winter Leathers Jackets" width="300" className="product-img default" />
                                            <img src={"./assets/images/products/" + pr.product_type} alt="Mens Winter Leathers Jackets" width="300" className="product-img hover" /> */}

                                            {/* <p className="showcase-badge">{pr.sale_percent}</p>
                                            <p className="showcase-badge angle black">sale</p> */}
                                            {pr.published ? (
                                                <p className="showcase-badge">{pr.sale_percent}</p>
                                            ) : (
                                                <p className="showcase-badge angle black">sale</p>
                                            )}
                                            <div className="showcase-actions">

                                                <button className="btn-action">
                                                    <IonIcon icon={heartOutline} />
                                                </button>

                                                <button className="btn-action">
                                                    <IonIcon icon={eyeOutline} />
                                                </button>

                                                <button className="btn-action">
                                                    <IonIcon icon={repeatOutline} />
                                                </button>

                                                <button className="btn-action">
                                                    <IonIcon icon={bagAddOutline} />
                                                </button>

                                            </div>

                                        </div>

                                        <div className="showcase-content">

                                            <a href="#" className="showcase-category">{getCategoryName(pr.id)}</a>

                                            <a href="#">
                                                <h3 className="showcase-title">{pr.product_name}</h3>
                                            </a>

                                            <div className="showcase-rating">
                                                <IonIcon icon={star} />
                                                <IonIcon icon={star} />
                                                <IonIcon icon={star} />
                                                <IonIcon icon={starOutline} />
                                                <IonIcon icon={starOutline} />

                                            </div>

                                            <div className="price-box">
                                                <p className="price">${pr.sale_price}.00</p>
                                                <del>${pr.buying_price}.00</del>
                                            </div>

                                        </div>

                                    </div>
                                ))}
                        </div>

                    </div>

                </div>

            </div>

        </div>
    );
}
export default Product