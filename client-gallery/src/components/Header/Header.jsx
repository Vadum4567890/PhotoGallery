import React, { useEffect, useState } from 'react';
import styles from '../../styles/Header.module.css';

import { Link, NavLink, useNavigate } from 'react-router-dom';

import { ROUTES } from '../../utils/routes';


import ACCOUNT from '../../images/header/User.svg';
import { useDispatch, useSelector } from 'react-redux';
import { logOut, toggleForm } from '../../features/user/userSlice';
import UserForm from '../User/UserForm';
import { jwtDecode } from 'jwt-decode';
import { createAlbum } from '../../features/album/albumSlice';
import BasicModal from '../AdditionalComponents/BasicModal';



const Header = () => {
    const navigate = useNavigate()
    const dispatch = useDispatch();
    const { currentUser } = useSelector(({ user }) => user);
    


    const handleClick = () => {
        if (!currentUser) dispatch(toggleForm(true));
    }


    const handleLogout = () => {
        try {
          dispatch(logOut());
          navigate("/")
          window.location.reload();
        } catch (error) {
          console.error("Error during logout:", error);
          navigate("/")
        }
    };

  return (
    <>
    <div className={styles.header}>
        <div className={styles.headercontent}>
        {
                localStorage.getItem('token') !== null ? (
                    <div className={styles.title}>
                        <BasicModal/>
                    </div>
                  
                ) : (<></>)
        }
        <div className={styles.title}>
            <h1><NavLink to="/">Photo Gallery</NavLink></h1>
        </div>
            <div className={styles.account}>
            {
                localStorage.getItem('token') !== null ? (
                    <div className={styles.accountleave}>
                        <button onClick={handleLogout}><p>Leave</p></button>
                    </div>
                  
                ) : (
                    <Link className={styles.accounticon} onClick={handleClick}>
                        <img src={ACCOUNT} alt="account" />
                    </Link>
                    
                )
            }
             
            </div>
        </div>
    </div>
    <UserForm/>
    
 </>
  )
}

export default Header