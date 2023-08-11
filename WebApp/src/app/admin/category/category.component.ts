import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  constructor(private service:SharedService) { }
  showCreateCategoryModal = false;
  selectedItem:any;
  listCategories: any = [];
  isEditEnabled = false;

  ngOnInit(): void {
    this.reloadCategories();
  }

  reloadCategories() {
    this.service.getAllCategories().subscribe(data => {
      this.listCategories = data;
    })
  }

  onRowClick(item: number) {
    this.selectedItem = item;
    this.isEditEnabled = true;
  }

  openCategoryModal() {
    this.showCreateCategoryModal = true;
  }

  
}
