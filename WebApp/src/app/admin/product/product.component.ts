import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  constructor(private service:SharedService) { }

  listProducts: any = [];

  ngOnInit(): void {
    this.reloadProducts();
  }

  reloadProducts() {
    this.service.getAllProducts().subscribe(data => {
      this.listProducts = data;
    })
  }
}
