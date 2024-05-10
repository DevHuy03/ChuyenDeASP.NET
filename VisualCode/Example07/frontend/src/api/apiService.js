import axios from 'axios';

let API_URL="http://localhost:5019/api";

export async function callApi (endpoint, method='GET', body) {

        try {
        return await axios({
            method,
            url: `${API_URL}/${endpoint}`,
            data: body,
        });
    } catch (e) {
        console.log(e);
    }
}
//Servise PRODUCT
export function GET_ALL_PRODUCTS(endpoint) {

    return callApi(endpoint, "GET");

}

export function GET_PRODUCT_ID(endpoint, id) {

    return callApi(endpoint+"/"+id, "GET");

}

export function POST_ADD_PRODUCT(endpoint, data) {

    return callApi(endpoint, "POST", data);

}

export function PUT_EDIT_PRODUCT(endpoint, data) {

    return callApi(endpoint, "PUT", data);

}

export function DELETE_PRODUCT_ID(endpoint) { 

    return callApi(endpoint, "DELETE");

}
//Servise CATEGORY
export function GET_ALL_CATEGORIES(endpoint) {

    return callApi(endpoint, "GET");

}
export function GET_CATEGORY_ID(endpoint, id) {

    return callApi(endpoint+"/"+id, "GET");

}
export function POST_ADD_CATEGORY(endpoint, data) {

    return callApi(endpoint, "POST", data);

}
export function PUT_EDIT_CATEGORY(endpoint, data) {

    return callApi(endpoint, "PUT", data);

}
export function DELETE_CATEGORY_ID(endpoint) { 

    return callApi(endpoint, "DELETE");

}
//Servise TAG
export function GET_ALL_TAG(endpoint) {

    return callApi(endpoint, "GET");

}
export function GET_TAG_ID(endpoint, id) {

    return callApi(endpoint+"/"+id, "GET");

}
export function POST_ADD_TAG(endpoint, data) {

    return callApi(endpoint, "POST", data);

}
export function PUT_EDIT_TAG(endpoint, data) {

    return callApi(endpoint, "PUT", data);

}
export function DELETE_TAG_ID(endpoint) { 

    return callApi(endpoint, "DELETE");

}
//Servise Gallery
export function GET_ALL_GALLERY(endpoint) {

    return callApi(endpoint, "GET");

}
export function GET_GALLERY_ID(endpoint, id) {

    return callApi(endpoint+"/"+id, "GET");

}
export function POST_ADD_GALLERY(endpoint, data) {

    return callApi(endpoint, "POST", data);

}
export function PUT_EDIT_GALLERY(endpoint, data) {

    return callApi(endpoint, "PUT", data);

}
export function DELETE_GALLERY_ID(endpoint) { 

    return callApi(endpoint, "DELETE");

}
//Servise Product_Category
export function GET_ALL_PRODUCT_CATEGORY(endpoint) {

    return callApi(endpoint, "GET");

}
export function GET_PRODUCT_CATEGORY_ID(endpoint, id) {

    return callApi(endpoint+"/"+id, "GET");

}
export function POST_ADD_PRODUCT_CATEGORY(endpoint, data) {

    return callApi(endpoint, "POST", data);

}
export function PUT_EDIT_PRODUCT_CATEGORY(endpoint, data) {

    return callApi(endpoint, "PUT", data);

}
export function DELETE_PRODUCT_CATEGORY_ID(endpoint) { 

    return callApi(endpoint, "DELETE");

}
//Servise Product_Tag
export function GET_ALL_PRODUCT_TAG(endpoint) {

    return callApi(endpoint, "GET");

}
export function GET_PRODUCT_TAG_ID(endpoint, id) {

    return callApi(endpoint+"/"+id, "GET");

}
export function POST_ADD_PRODUCT_TAG(endpoint, data) {

    return callApi(endpoint, "POST", data);

}
export function PUT_EDIT_PRODUCT_TAG(endpoint, data) {

    return callApi(endpoint, "PUT", data);

}
export function DELETE_PRODUCT_TAG_ID(endpoint) { 

    return callApi(endpoint, "DELETE");

}