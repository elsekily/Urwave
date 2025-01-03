import { baseResponse } from "./baseResponse";
import { productResource } from "./ProductResource";



export interface productResponse extends baseResponse {
    data: productResource;
}
