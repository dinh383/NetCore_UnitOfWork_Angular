import { VideoModule } from '@app/main/modules/resoure-management/video/video.module';
import { VideoComponent } from '@app/main/modules/resoure-management/video/video.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResoureManagementComponent } from '@app/main/modules/resoure-management/resoure-management.component';
import { RouterModule } from '@angular/router';
import { resoureRoutes } from '@app/main/modules/resoure-management/resoure-management.routing';

@NgModule({
  imports: [
    CommonModule,
    VideoModule,
    RouterModule.forChild(resoureRoutes)
  ],
  declarations: [
    ResoureManagementComponent
  ]
})
export class ResoureManagementModule { }
