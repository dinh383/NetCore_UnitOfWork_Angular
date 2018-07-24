import { BaseController } from '@app/core/common/baseController';

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '@app/core/services/data.service';
import { Menu } from '@app/shared/models/menuVM';
import { AuthenService } from '@app/core/services/authen.service';

@Component({
  selector: 'app-sidebar-menu',
  templateUrl: './sidebar-menu.component.html',
  styleUrls: ['./sidebar-menu.component.css']
})
export class SidebarMenuComponent extends BaseController implements OnInit {
  lstMenu: Menu[];
  currentItem: Menu;
  userName: string;
  constructor(private router: Router, private _authenService: AuthenService, private _dataService: DataService) {
    super();
  }

  ngOnInit() {
    this.userName = this._authenService.getLoggedInUser().username;
    //this.getMenus();
    this.lstMenu = this.getListMenus();
  }
  getMenus() {
    return this._dataService.get('api/permissions/GetListMenus?isGetAll=false').subscribe((response: any) => {
      // this.lstMenu = response;
      this.lstMenu = this.getListMenus();
      console.log(this.lstMenu);
      this.currentItem = this.lstMenu[0];
    }, error => this._dataService.handleError(error));
  }
  selectItem(e) {
    debugger;
    this.currentItem = e.itemData;
    this.router.navigate([e.itemData.routerLink]);
  }
  getListMenus() {
    const menus =
      [
        {
          "id": "manage-student", "text": "QUẢN LÝ HỌC VIÊN", "expanded": true, "routerLink": "/",
          "items":
            [
              { "id": "1", "text": "Đăng ký tư vấn", "expanded": false, "routerLink": "/main/home-study/register-list", "items": [] },
              { "id": "2", "text": "Danh sách học thử", "expanded": false, "routerLink": "/main/home-study/register-list", "items": [] },
              { "id": "3", "text": "Danh sách học viên", "expanded": false, "routerLink": "/main/home-study/register-list", "items": [] }
            ]
        },
        {
          "id": "resource-management", "text": "QUẢN LÝ TÀI NGUYÊN", "expanded": true, "routerLink": "/",
          "items":
            [
              { "id": "4", "text": "Danh sách video", "expanded": false, "routerLink": "/main/resoure-management/video-list", "items": [] }
            ]
        }
      ]
    return menus;
  }
}


