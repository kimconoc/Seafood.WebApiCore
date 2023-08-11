import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CategoryComponent } from './admin/category/category.component';
import { ProductComponent } from './admin/product/product.component';

const routes: Routes = [
  { path: 'category', component:CategoryComponent },
  { path: 'product', component:ProductComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
