
import { Route, Routes } from "react-router-dom";
import "./assets/scss/app.scss"; 
import Main from "./layouts/Main";
import HomeAdmin from "./components/HomeAdmin";
import AddProduct from "./components/Product/AddProduct";
import Product from "./components/Product/Index";
import EditProduct from "./components/Product/EditProduct";
function App() {
  return (
    <Routes>
      <Route path="/" element={<Main />} />
      <Route path="/admin" element={<HomeAdmin />}>
          <Route index element={<Product />} />
          <Route path="addproducts" element={<AddProduct />} />
          <Route path="/admin/editproduct/:id" element={<EditProduct />} />

      </Route>
    </Routes>
  );
}

export default App;
