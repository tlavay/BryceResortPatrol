import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  public isLogoHidden: boolean;
  private componentsMap: Map<string, boolean> = new Map<string, boolean>();

  ngOnInit() {
    this.componentsMap.set('about', true);
    this.componentsMap.set('candidacy', false);
    this.componentsMap.set('history', false);
    this.componentsMap.set('join', false);
    if (window.screen.width < 376) {
      this.isLogoHidden = true;
    }
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
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
