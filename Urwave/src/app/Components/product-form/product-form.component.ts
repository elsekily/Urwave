import { Component, Input } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { productResource } from '../../Models/ProductResource';
import { ProductService } from '../../Services/product.service';
import { ProductRequest } from '../../Models/ProductRequest';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrl: './product-form.component.css',
  providers: [],
})
export class ProductFormComponent {
  @Input() product: productResource | null = null;
  productForm: FormGroup;
  productId: number | null = null;
  
  constructor(
    private fb: FormBuilder,
    private productService: ProductService,
    private route: ActivatedRoute,
    private router: Router,
  ) {
    this.productForm = this.fb.group({
      id: [{ value: null, disabled: true }],
      name: ['', [Validators.required, Validators.maxLength(100)]],
      description: ['', [Validators.required, Validators.maxLength(500)]],
      price: ['', [Validators.required, Validators.min(0)]],
    });
  }

  ngOnInit(): void {
    this.productId = +this.route.snapshot.paramMap.get('id')!;
    if (this.productId) {
      this.productService.getProduct(this.productId).subscribe((response) => {
        if (response.isSuccess) {
          this.productForm.patchValue(response.data);
        }
        else {
          alert(response.message);
          this.router.navigate(['/products']);
        }
      });
    }
  }

  onSubmit(): void {
    if (!this.productForm.valid) {
      return;
    }
    const productData: ProductRequest = this.mapToProductRequest(this.productForm.value);
    const saveProduct = this.productId
      ? this.productService.update(this.productId, productData)
      : this.productService.create(productData);
    
    saveProduct.subscribe((response) => {
      if (response.isSuccess) {
        alert(response.message);
      }
      this.router.navigate(['/products']);
    });
  }

  get isFormValid() {
    return this.productForm.valid;
  }

  mapToProductRequest(resource: productResource): ProductRequest {
    return {
        name: resource.name,
        description: resource.description,
        price: resource.price,
    };
}
}
