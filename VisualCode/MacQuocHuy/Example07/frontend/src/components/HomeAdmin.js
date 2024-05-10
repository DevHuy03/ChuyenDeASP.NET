import React from "react";
import MenuTop from "./MenuTop";
import { Outlet } from "react-router-dom";
function HomeAdmin(props) {
  return (
    <>
    <MenuTop />
    <Outlet />
    </>
  );
} export default HomeAdmin; 
