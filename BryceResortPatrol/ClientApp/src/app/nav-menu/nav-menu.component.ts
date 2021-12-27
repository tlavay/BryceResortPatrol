import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NavType } from '../models/nav-type';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  public isLogoHidden: boolean;
  public componentsMap: Map<string, boolean> = new Map<string, boolean>();
  private currentNavType: NavType;
  private memberNavItems: string[] = [
    'members',
    'schedule'
  ];

  constructor(private route: Router) { }

  ngOnInit() {
    this.updateNavItems(NavType.Public);
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

  public navItemClick(name: string) {
    const isMemberNavItem = this.memberNavItems.find(x => x === name);
    if (isMemberNavItem && this.currentNavType === NavType.Public) {
      this.updateNavItems(NavType.Member);
    }

    if (this.currentNavType === NavType.Member) {
      this.route.navigate([`/members/${name}`]);
    } else {
      this.route.navigate([`/${name}`]);
    }

    this.focus(name);
  }

  public focus(name: string) {
    this.componentsMap.forEach((value, key) => {
      this.componentsMap.set(key, false);
    });
    this.componentsMap.set(name, true);
    window.history.replaceState({}, '', '/' + name);
  }

  public capitalizeFirstLetter(input: string): string {
    if (input) {
      return input.charAt(0).toUpperCase() + input.slice(1);
    }
    return input;
  }

  private updateNavItems(navType: NavType) {
    this.componentsMap = new Map<string, boolean>();
    switch (navType) {
      case NavType.Member:
        this.componentsMap.set('members', true);
        this.componentsMap.set('schedule', false);
        this.currentNavType = navType;
        break;
      default:
        this.componentsMap.set('about', true);
        this.componentsMap.set('candidacy', false);
        this.componentsMap.set('history', false);
        //this.componentsMap.set('members', false);
        this.componentsMap.set('join', false);
        this.currentNavType = navType;
        break;
    }
  }
}
