
import { Component, OnInit, ViewChild } from '@angular/core';
import { BaseController } from '@app/core/common/baseController';
import { DxDataGridComponent } from 'devextreme-angular';
import { DataService } from '@app/core/services/data.service';
import * as AspNetData from "devextreme-aspnet-data";
import { SystemConstants } from '@app/core/common/system.constants';
import notify from 'devextreme/ui/notify';
import { TitlePopup } from '@app/shared/models/title-popup';
import { IButtonLinkModel } from '@app/shared/models/buttonLinkModel';
import { ButtonType } from '@app/shared/enums/buttonType';
import { methodType } from '@app/shared/enums/methodType';
import { CommonLib } from '@app/core/library/commonLib';
import { DataGrid } from '@app/core/library/dxDataGrid';

@Component({
  selector: 'app-register-consultative',
  templateUrl: './register-consultative.component.html',
  styleUrls: ['./register-consultative.component.css']
})
export class RegisterConsultativeComponent extends BaseController implements OnInit {

  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent;
  titlePage: string = 'công ty';
  titlePopup: TitlePopup;
  dataSource: any;
  entity: any;
  popupVisible = false;
  popupVisibleDel = false;
  constructor(private _dataService: DataService) {
    super();
  }

  ngOnInit() {
    this.titlePopup = new TitlePopup(true, 'khách hàng');
    this.initGrid();
    this.onAddButtonLink();
    this.fileNameExport = CommonLib.getFileNameExport("Danh sách công ty");
  }
  //---------------Menu Footer ---------------

  onAddButtonLink() {
    let btnAdd: IButtonLinkModel = {
      id: 1, buttonType: ButtonType.Add, label: "Thêm", ordinal: 1, icon: "fa fa-plus", visibility: true, disabled: true,
      handler: () => {
        this.InitNewRow();
      }
    }
    this.addNewButtonLink(btnAdd);

    let btnRegisterLearnTrial: IButtonLinkModel = {
      id: 2, buttonType: ButtonType.Add, label: "Đăng ký học thử", ordinal: 1, icon: "fa fa-address-card-o", visibility: true, disabled: true,
      handler: () => {
        this.registerLearnTrial();
      }
    }
    this.addNewButtonLink(btnRegisterLearnTrial);

    let btnRegisterClass: IButtonLinkModel = {
      id: 3, buttonType: ButtonType.Add, label: "Ghi danh học viên", ordinal: 1, icon: "fa fa-user-plus", visibility: true, disabled: true,
      handler: () => {
        this.registerClass();
      }
    }
    this.addNewButtonLink(btnRegisterClass);
  }

  registerLearnTrial() {
    alert('DK hoc thu')
  }
  registerClass() {
    alert('Ghi danh hoc')
  }
  onHidenButton() {
    let button: IButtonLinkModel = {
      buttonType: ButtonType.Edit,
      visibility: false
    }
    this.updateButtonLink(button);
  }
  //-----------

  //get list
  initGrid() {
    this.dataSource = AspNetData.createStore({
      key: "registerId",
      loadUrl: SystemConstants.BASE_API + "api/registerConsultative/getAll"
    });
  }


  //cancel popup
  cancelPopup(action) {
    if (action == 'del') {
      this.popupVisibleDel = false;
    } else {
      this.popupVisible = false;
    }
  }

  //click add new
  async InitNewRow() {
    debugger;
    this.titlePopup = new TitlePopup(true, this.titlePage);

    this.entity = {
      lineID: null,
      companyID: null,
      companyName: '',
      description: '',
      Action: 'add'
    }
    this.popupVisible = true;
  }


  EditingStart(e) {
    debugger;
    this.titlePopup = new TitlePopup(false, this.titlePage);
    return this._dataService.get('api/company/GetSingleById?lineID=' + e.data.lineID).subscribe((response: any) => {
      this.entity = response.company;
      this.popupVisible = true;
    }, error => this._dataService.handleError(error));
  }

  async Add() {
    let result = false;
    let url = SystemConstants.BASE_API + 'api/company/Add';
    let params = this.entity;
    const res = await this._dataService.callServiceAsync({ url, params }, methodType.POST)
      .then(data => {
        // console.log('data',data);
        if (data) {
          result = true;
          notify("Thêm thành công công ty", "success", 600);
        }
        else {
          notify(data.statusName, "error", 600);
        }
      })
      .catch(() => {
        result = false;
      });
    return result;
  }

  async Update() {
    let value = false;
    let url = SystemConstants.BASE_API + 'api/company/Update';
    let params = this.entity;
    const res = await this._dataService.callServiceAsync({ url, params }, methodType.PUT)
      .then(data => {
        value = true;
        notify("Cập nhật thành công công ty", "success", 600);
      })
      .catch(() => {
        value = false;
      });
    return value;
  }
  //submit for add, edit
  async Editing(e) {
    debugger;
    e.preventDefault();

    let value = false;
    if (this.entity.Action == 'add') {
      value = await this.Add();
    } else {
      value = await this.Update();
    }
    if (value) {
      this.popupVisible = false;
      new DataGrid().reloadDataSource(this.dataGrid);
    }
    else {
      notify("Không thành công", "error", 600);
    }
  }


  RemoveStart(e) {
    this.entity = e.data;
    this.popupVisibleDel = true;
  }

  RowRemoving() {
    this._dataService.delete('api/company/Delete', "lineID", this.entity.lineID.toString()).subscribe((response: any) => {
      // console.log('response',response);
      //Gọi lại hàm reload cái gird đê update dư liệu từ DB
      this.popupVisibleDel = false;
      if (response.company == null) {
        notify("Không xóa được. Tồn tại nhân viên thuộc công ty này", "error", 600);
      } else {
        notify("Xóa thành công công ty", "success", 600);
      }
      new DataGrid().reloadDataSource(this.dataGrid);
    }, error => {
      // console.log('fail');
      new DataGrid().reloadDataSource(this.dataGrid);
      this._dataService.handleError(error);
    });
  }

}
