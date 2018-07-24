import { Component, OnInit, ViewChild } from '@angular/core';
import * as AspNetData from "devextreme-aspnet-data";
import { SystemConstants } from '@app/core/common/system.constants';
import { DxDataGridComponent } from '../../../../../../node_modules/devextreme-angular';

@Component({
  selector: 'app-video',
  templateUrl: './video.component.html',
  styleUrls: ['./video.component.css']
})
export class VideoComponent implements OnInit {
  dataSource: any;
  events: Array<string> = [];
  constructor() {

  }
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent;

  ngOnInit() {
    this.initGrid();
  }

  initGrid() {
    this.dataSource = AspNetData.createStore({
      key: "lineId",
      loadUrl: SystemConstants.BASE_API + "api/video/getAll",
      insertUrl: SystemConstants.BASE_API + "api/video/InsertOnGrid",
      updateUrl: SystemConstants.BASE_API + "api/video/UpdateOnGrid",
      deleteUrl: SystemConstants.BASE_API + "api/video/DeleteOnGrid",
      onBeforeSend: function(method, ajaxOptions) {
          ajaxOptions.xhrFields = { withCredentials: true };
      }
  });

  }

  // onContentReady(e) {
  //   e.component.columnOption("command:edit", {
  //     visibleIndex: -1
  //   });
  // }
}
