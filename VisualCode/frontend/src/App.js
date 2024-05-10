
import { Route, Routes } from "react-router-dom";
import "./assets/scss/app.scss";
import Home from "./layouts/Home";
import HomeAdmin from "./components/HomeAdmin";
import AddProduct from "./components/AddProduct";
function App() {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/admin" element={<HomeAdmin />} />
      <Route path="/addproducts" element={<AddProduct />} />
      {/* <Route path="/edit/product/:id" element={<EditProduct />} /> */}
    </Routes>
  );
}

export default App;
