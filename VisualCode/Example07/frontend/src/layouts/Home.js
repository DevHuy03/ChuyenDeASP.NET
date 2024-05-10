import Blog from "../pages/home/Blog";
import Category from "../pages/home/Category";
import Modal from "../pages/home/Modal";
import Notification from "../pages/home/Notification";
import Product from "../pages/home/Product";
import Slider from "../pages/home/Slider";
import Testimonial from "../pages/home/Testimonial";
function Home(props) {
  return (
    <>
      <Modal />
      <Notification />
      <Slider />
      <Category />
      <Product />
      <Testimonial />
      <Blog />
    </>
  );
} export default Home; 
