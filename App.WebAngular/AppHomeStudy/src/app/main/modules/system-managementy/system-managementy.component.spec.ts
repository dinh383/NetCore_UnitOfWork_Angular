import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SystemManagementyComponent } from '@app/main/modules/system-managementy/system-managementy.component';

describe('SystemManagementyComponent', () => {
  let component: SystemManagementyComponent;
  let fixture: ComponentFixture<SystemManagementyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SystemManagementyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SystemManagementyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
