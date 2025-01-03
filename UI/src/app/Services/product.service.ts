import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { productResponse } from '../Models/productResponse';
import { productsResponse } from '../Models/productsResponse';
import { baseResponse } from '../Models/baseResponse';
import { ProductRequest } from '../Models/ProductRequest';
import { environment } from '../../environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

   constructor(private http: HttpClient) { }

  baseUrl = environment.apiUrl + 'products';

  create(product:ProductRequest) {
    return this.http.post<productResponse>(this.baseUrl, product);
  }
  update(id:number,product:ProductRequest) {
    return this.http.put<productResponse>(this.baseUrl +'/'+ id, product);
  }
  getProduct(id:number) {
    return this.http.get<productResponse>(this.baseUrl+'/'+ id);
  }
  getProducts() {
    return this.http.get<productsResponse>(this.baseUrl);
  }
    deleteProduct(id:number) {
    return this.http.delete<baseResponse>(this.baseUrl+'/'+ id);
  }

}
