import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { Product } from 'src/app/_models/product';
import { ProductService } from 'src/app/_services/product.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  newProduct1: Product = {
    id: '',
    name: '',
    price: 0,
    imgPath: '',
    modelNumber: '',
    manufacture: '',
    details: '',
    count: 0,
    brandId: 0,
    categoryId: 0,
  };
  product: any;
  constructor(public prd: ProductService , public act:ActivatedRoute , public router:Router,
    public productService: ProductService
    
   
    ) { }

  ngOnInit(): void {
    this.details()
  }

  // this.route.queryParams
  // .subscribe(params => {
  //   console.log(params); // { orderby: "price" }
  //   this.orderby = params.orderby;
  //   console.log(this.orderby); // price
  // }


details() {
  this.act.queryParams
  .subscribe((params: any) => {
    console.log("params", params); // { orderby: "price" }
   this.viewinfo(params?.id);
  }
  )
// this.act.params.subscribe(a=>{
//   let id = a['id']
//   console.log("details", a);
//   this.viewinfo(id);
// })
}

viewinfo(id:any){
  console.log(id);
  this.productService.GetProductById(id).subscribe((product) => {
    console.log("product", product)
    this.product = product;


  })
}

addToCart(item?: any) {
  console.log("cardId", item);
  let user: any =  localStorage.getItem('userDetail')
  
  
  console.log("getUser localStorage.setItem('token', response.token)", JSON.parse(user) );
  let productObj;
  productObj = {
    productId: this.product?.id,
    count: 1,
    userId: JSON.parse(user)?.id,
  }
  this.prd.AddProductToCard(productObj).subscribe((a) => {

  });
}




}

