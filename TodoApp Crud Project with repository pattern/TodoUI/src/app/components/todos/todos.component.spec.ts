import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TodosComponent } from './todoscomponent';

describe('todoscomponent', () => {
  let component: TodosComponent;
  let fixture: ComponentFixture<TodosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TodosComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TodosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
