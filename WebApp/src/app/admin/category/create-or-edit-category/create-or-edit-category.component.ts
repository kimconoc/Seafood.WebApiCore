import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-create-or-edit-category',
  templateUrl: './create-or-edit-category.component.html',
  styleUrls: ['./create-or-edit-category.component.css']
})
export class CreateOrEditCategoryComponent implements OnInit {
  code: string = "";
  note: string = "";
  name: string = "";
  description: string = "";
  icon: string = "";
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  @Input() selectedItem: any;
  constructor(private service: SharedService, private http:HttpClient) { }

  ngOnInit() {
  }

  save() {
    var val = {
      name: this.selectedItem.name,
      code: this.selectedItem.code,
      note: this.selectedItem.note,
      description: this.selectedItem.description,
      icon: this.selectedItem.icon
    };
    if (this.selectedItem.id == null) {
      this.service.createCategories(val).subscribe(res => {
        alert('Thêm mới thành công!');
        this.modalSave.emit(null);
      })
    }
    else {
      this.service.updateCategories(this.selectedItem.id, val).subscribe();
      // this.http.put<any>("https://localhost:7195/api/"+'Categories/'+this.selectedItem.id, val).subscribe();
      alert('Sửa thành công!');
    }
  }
}