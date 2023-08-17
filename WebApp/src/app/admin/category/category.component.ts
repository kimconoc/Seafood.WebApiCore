import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SharedService } from 'src/app/shared.service';
@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  constructor(private service: SharedService , private router: Router) { }
  showCreateCategoryModal = false;
  selectedItem: any;
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
    this.isEditEnabled = true;

    if (this.selectedItem) {
      const previousRow = document.querySelector('.selected');
      if (previousRow) {
        previousRow.classList.remove('selected');
        previousRow.classList.add('previous');
      }
    }
  
    this.selectedItem = item;
  }

  createModal() {
    this.selectedItem = new Object();
    this.showCreateCategoryModal = true;
  }

  editModal() {
    this.showCreateCategoryModal = true;
  }

  delete() {
    const confirmed = confirm('Bạn có chắc chắn muốn xóa bản ghi có tên "' + this.selectedItem.name + '" không?');
    if (confirmed) {
      this.service.deleteCategories(this.selectedItem.id).subscribe(res => {
        this.reloadCategories();
      });
    }
  }

  back() {
    this.router.navigate(['login/home']);
  }
}

