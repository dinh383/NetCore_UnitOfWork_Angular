import { VideoComponent } from '@app/main/modules/resoure-management/video/video.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '../../../../../../node_modules/@angular/platform-browser';
import { DxDataGridModule, DxButtonModule } from '../../../../../../node_modules/devextreme-angular';

@NgModule({
  imports: [
    CommonModule,
    DxDataGridModule,
    DxButtonModule
  ],
  declarations: [
    VideoComponent
  ]
})
export class VideoModule { }
