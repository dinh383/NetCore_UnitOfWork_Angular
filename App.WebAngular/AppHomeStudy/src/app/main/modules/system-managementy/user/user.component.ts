import { Http } from '@angular/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';
import { BaseController } from '@app/core/common/baseController';
import * as AspNetData from "devextreme-aspnet-data";
import { SystemConstants } from '@app/core/common/system.constants';
import notify from 'devextreme/ui/notify';
import { DataGrid } from '@app/core/library/dxDataGrid';
import { DataService } from '@app/core/services/data.service';
import { TitlePopup } from '@app/shared/models/title-popup';
import { CommonLib } from '@app/core/library/commonLib';
import { IButtonLinkModel } from '@app/shared/models/buttonLinkModel';
import { ButtonType } from '@app/shared/enums/buttonType';
import { User } from '@app/shared/models/user';
import { methodType } from '@app/shared/enums/methodType';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent extends BaseController implements OnInit {
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent;
  dataSource: any;
  titlePopup: any;
  entity: any;
  popupVisible = false;
  popupVisibleDel = false;
  lstGroup: any[];
  isEnable: boolean = false;

 
  constructor(private _http: Http, private _dataService: DataService) {
    super();
    this.titlePopup = new TitlePopup(true, 'vé tháng');
  }

  ngOnInit() {
    this.initGrid();
    this.onAddButtonLink();
    this.fileNameExport = CommonLib.getFileNameExport("Danh sách người dùng");
  }
  onAddButtonLink() {
    let button1: IButtonLinkModel = {
      id: 1, buttonType: ButtonType.Add, label: "Thêm", ordinal: 1, icon: "fa fa-plus", visibility: true, disabled: true,
      handler: () => {
        this.InitNewRow();
      }
    }
    this.addNewButtonLink(button1);

  }
  initGrid() {
    debugger;
    this.dataSource = AspNetData.createStore({
      key: "id",
      loadUrl: SystemConstants.BASE_API + "api/AppUser/GetAll"
    });
  }

  getListGroup() {

    this._dataService.get('api/AppUser/GetUserRoleVM?userID=').subscribe((response: any) => {
      debugger;
      this.lstGroup = response.roles;
    }, error => this._dataService.handleError(error));
  }
  //cancel popup
  cancelPopup(action) {
    debugger;
    if (action == 'del') {
      this.popupVisibleDel = false;
    } else {
      this.entity = null;
      this.popupVisible = false;
    }
  }

  //click add new
  // async InitNewRow(e) {
  //   this.titlePopup = new TitlePopup(true, 'người dùng');
  //   e.cancel = true;
  //   window.setTimeout(function () { e.component.cancelEditData(); }, 0);
  //   this.popupVisible = true;
  //   this.entity = new User("add");
  //   this.isEnable = false;
  //   this.getListGroup();
  // }

  //click add new
  async InitNewRow() {
    debugger;
    this.titlePopup = new TitlePopup(true, 'người dùng');
    this.entity = new User("add");
    this.getListGroup();
    this.popupVisible = true;
  }



  //start edit row
  EditingStart(e) {
    debugger;
    this.isEnable = true;
    this.titlePopup = new TitlePopup(false, "người dùng");
    // return this._dataService.get('api/AppUser/GetSingleByUseName?userName=' + e.data.userName).subscribe((response: any) => {
    return this._dataService.get('api/AppUser/GetUserRoleVM?userID=' + e.data.id).subscribe((response: any) => {
      debugger;
      this.entity = response.user;
      this.lstGroup = response.roles;
      this.popupVisible = true;
    }, error => this._dataService.handleError(error));
  }

  async Add() {
    debugger;
    let result = false;
    let url = SystemConstants.BASE_API + 'api/AppUser/AddRolesForUser';
    let params = {
      User: this.entity,
      Roles: this.lstGroup,
      ListRoleID: null
    }
    const res = await this._dataService.callServiceAsync({ url, params }, methodType.POST)
      .then(data => {
        if (data.user) {
          result = true;
          notify("Thêm thành công", "success", 1000);
        } else {
          notify("Thông tin người dùng đã tồn tại", "error", 1000);
        }
      })
      .catch(() => {
        result = false;

      });
    return result;
  }

  async Update() {
    let value = false;
    let url = SystemConstants.BASE_API + 'api/AppUser/UpdateRolesForUser';
    let params = {
      User: this.entity,
      Roles: this.lstGroup,
      ListRoleID: null
    }
    const res = await this._dataService.callServiceAsync({ url, params }, methodType.POST)
      .then(data => {
        if (data.user) {
          value = true;
          notify("Cập nhật thành công", "success", 1000);
        } else {
          notify("Thông tin người dùng đã tồn tại", "error", 1000);
        }
      })
      .catch(() => {
        value = false;
        notify("Cập nhật bị lỗi", "error", 1000);
      });
    return value;
  }

  //submit for add, edit
  async Editing(e) {
    debugger;
    e.preventDefault();
    let value = false;
    if (this.entity.action == 'add') {

      value = await this.Add();
    } else {
      value = await this.Update();
    }
    if (value) {
      this.popupVisible = false;
      new DataGrid().reloadDataSource(this.dataGrid);
    }
    else {
      notify("Không thành công", "error", 1000);
    }
  }

  RemoveStart(e) {
    this.entity = e.data;
    this.popupVisibleDel = true;
  }

  RowRemoving() {
    this._dataService.delete('api/AppUser/Delete', "userID", this.entity.id).subscribe((response: any) => {
      // console.log('response',response);
      //Gọi lại hàm reload cái gird đê update dư liệu từ DB
      this.popupVisibleDel = false;
      new DataGrid().reloadDataSource(this.dataGrid);
      notify("Xoá thành công!", "success", 1000);
    }, error => {
      // console.log('fail');
      new DataGrid().reloadDataSource(this.dataGrid);
      notify("Xoá thất bại", "error", 1000);
      this._dataService.handleError(error);
    });
  }
}