import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SharedService } from 'src/app/shared.service';
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  constructor(private service:SharedService, private router : Router) { }

  listProducts: any = [];

  ngOnInit(): void {
    this.reloadProducts();
  }

  reloadProducts() {
    this.service.getAllProducts().subscribe(data => {
      this.listProducts = data;
    })
  }

  back() {
    this.router.navigate(['login/home']);
  }
}
