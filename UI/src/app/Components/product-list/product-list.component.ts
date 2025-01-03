import { Component } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { productsResponse } from '../../Models/productsResponse';
import { productResource } from '../../Models/ProductResource';
import { ConfirmationService } from 'primeng/api';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css',
  providers: [ConfirmationService]
})
export class ProductListComponent {

  products: productResource[] = [];
  filteredProducts: productResource[] = [];

  constructor(private productService: ProductService,
    private confirmationService: ConfirmationService,
  private router: Router) {
  }
  ngOnInit(): void {
    this.loadProducts();
  }


  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value.trim().toLowerCase();
    this.filteredProducts = this.products.filter(product =>
      product.name.toLowerCase().includes(filterValue)
    );
  }

   confirmDelete(productId: number) {
        this.confirmationService.confirm({
            message: 'Are you sure you want to delete this product?',
            accept: () => {
                this.deleteProduct(productId);
            }
        });
  }
  deleteProduct(productId: number) {
       this.productService.deleteProduct(productId).subscribe(
         (response) => {
           alert(response.message);
           this.loadProducts();
         }
    );
    }
  
  loadProducts() {
    let response = this.productService.getProducts().subscribe(
      (response) => {
        this.products = response.data;
        this.filteredProducts = [...this.products];
    },
      (error) => {
        alert('Error: ' + error.error);
      }
    );
  }
}
