import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserComponent } from '@app/main/modules/system-managementy/user/user.component';
import { DxTextBoxModule, DxTreeViewModule, DxDataGridModule, DxPopupModule, DxButtonModule, DxFormModule, DxCheckBoxModule } from 'devextreme-angular';
import { DataService } from '@app/core/services/data.service';
import { ButtonControlModule } from '@app/shared/layout/button-control/button-control.module';

const userRoutes: Routes = [
  { path: '', redirectTo: 'index', pathMatch: 'full' },
  { path: 'index', component: UserComponent }
]
@NgModule({
  imports: [
    CommonModule,
    DxDataGridModule,
    DxPopupModule,
    DxButtonModule,
    DxFormModule,
    DxCheckBoxModule,
    FormsModule,
    ButtonControlModule,
    RouterModule.forChild(userRoutes)
  ],
  declarations: [UserComponent],
  providers:[DataService]
})
export class UserModule { }
