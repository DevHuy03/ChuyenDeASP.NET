
import { Route, Routes } from "react-router-dom";
import "./assets/scss/app.scss"; 
import Main from "./layouts/Main";
import HomeAdmin from "./components/HomeAdmin";
import AddProduct from "./components/Product/AddProduct";
import Product from "./components/Product/Index";
import EditProduct from "./components/Product/EditProduct";
import IndexCat from "./components/Category/Index";
import AddCategory from "./components/Category/AddCategory";
import EditCategory from "./components/Category/EditCategory";
import IndexTag from "./components/Tag/Index";
import AddTag from "./components/Tag/AddTag";
import EditTag from "./components/Tag/EditTag";
import IndexGallery from "./components/Gallery/IndexGallery";
import AddGallery from "./components/Gallery/AddGallery";
import EditGallery from "./components/Gallery/EditGallery";
import ProductCategoryIndex from "./components/ProductCategory/ProductCategoryIndex";
import AddProductCategory from "./components/ProductCategory/AddProductCategory";
import ProductTagIndex from "./components/ProductTag/ProductTagIndex";
import AddProductTag from "./components/ProductTag/AddProductTag";
function App() {
  return (
    <Routes>
      <Route path="/" element={<Main />} />
      <Route path="/admin" element={<HomeAdmin />}>
          <Route index element={<Product />} />
          <Route path="addproducts" element={<AddProduct />} />
          <Route path="/admin/editproduct/:id" element={<EditProduct />} />
          <Route path="/admin/categories" element={<IndexCat />} />
          <Route path="/admin/addcategories" element={<AddCategory />} />
          <Route path="/admin/editcategories/:id" element={<EditCategory />} />
          <Route path="/admin/tags" element={<IndexTag />} />
          <Route path="/admin/addtags" element={<AddTag />} />
          <Route path="/admin/edittags/:id" element={<EditTag />} />
          <Route path="/admin/galleries" element={<IndexGallery />} />
          <Route path="/admin/addgalleries" element={<AddGallery />} />
          <Route path="/admin/editgalleries/:id" element={<EditGallery />} />
          <Route path="/admin/productcategories" element={<ProductCategoryIndex />} />
          <Route path="/admin/addproductcategories" element={<AddProductCategory />} />
          <Route path="/admin/producttags" element={<ProductTagIndex />} />
          <Route path="/admin/addproducttags" element={<AddProductTag />} />


      </Route>
    </Routes>
  );
}

export default App;
