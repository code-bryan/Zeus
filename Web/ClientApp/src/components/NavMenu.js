import React from 'react';
import { NavLink } from 'react-router-dom';
export default function NavMenu(props) {
    return (
        <>
            <div className="underSidebar" onClick={props.onToggle}/>
            <nav className="side-navbar">
                <div className="sidebar-header">
                    <div className="userAvatar">
                        <img src="https://sites.google.com/site/launiversidaduapa/_/rsrc/1445620575037/config/customLogo.gif?revision=3" alt="Uapa" className="img-fluid"/>
                    </div>
                </div>
                <ul className="list-unstyled" id="mainUl">
                    <li className="nav-item">
                        <NavLink className="text-dark" activeClassName="active" to="/Dashboard"><i className="icon icon-tachometer"/><span>Dashboard</span></NavLink>
                    </li>
                    <li className="nav-item">
                        <NavLink className="text-dark"  to="/seleccion"><i className="icon icon-files"/><span>Selección</span></NavLink>
                    </li>
                    <li className="nav-item">
                        <NavLink className="text-dark" to="/pensum"><i className="icon icon-envelope-o"/><span>Pensum</span></NavLink>
                    </li>
                    <li className="nav-item">
                        <NavLink className="text-dark"  to="/InfoPersonal"><i className="icon icon-files"/><span>Información Personal </span></NavLink>
                    </li>
                </ul>
                <div className="bottom">Versión: Preview</div>
            </nav>
        </>
    );
}