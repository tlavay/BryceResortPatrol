import { Component, OnInit } from '@angular/core';
import * as _ from 'lodash';
import { Location } from '@angular/common';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  private componentsMap: Map<string, boolean> = new Map<string, boolean>();

  constructor(private location: Location) {
  }

  ngOnInit() {
    this.componentsMap.set('about', true);
    this.componentsMap.set('candidacy', false);
    this.componentsMap.set('history', false);
    this.componentsMap.set('join', false);
    const currentPath = this.location.path();
    if (currentPath) {
      const lastForwardSlash = currentPath.lastIndexOf('/');
      const currentTab = currentPath.substring(lastForwardSlash + 1);
      this.focus(currentTab);
    }
  }

  public getActive(name: string): string {
    const base = 'nav-link pointer';
    const isActive = this.componentsMap.get(name);
    if (isActive && isActive === true) {
      return base + ' active';
    }
    return base;
  }

  public getIsFocus(name: string): boolean {
    const isActive = this.componentsMap.get(name);
    if (isActive && isActive === true) {
      return true;
    }
    return false;
  }

  public focus(name: string) {
    this.componentsMap.forEach((value, key) => {
      this.componentsMap.set(key, false);
    });
    this.componentsMap.set(name, true);
    window.history.replaceState({}, '', '/' + name);
  }
}
