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

  createCateogy() {
    var val = {
      name: this.selectedItem.name,
      code: this.selectedItem.code,
      note: this.selectedItem.note,
      description: this.selectedItem.description,
      icon: this.selectedItem.icon
    };
    if (this.selectedItem == '') {
      this.service.createCategories(val).subscribe(res => {
        alert(res.toString());
        this.name = '';
        this.code = '';
        this.note = '';
        this.description = '';
        this.icon = '';
        this.modalSave.emit(null);
      })
    }
    else {
      this.http.put<any>("https://localhost:7195/api/"+'Categories/'+this.selectedItem.id, val).subscribe(res => {
      })
    }
  }

}
