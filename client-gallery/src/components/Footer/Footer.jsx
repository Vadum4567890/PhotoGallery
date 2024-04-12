import React from 'react'
import styles from '../../styles/Footer.module.css';

import TELEGRAM from '../../images/footer/itelegram.svg';
import FACEBOOK from '../../images/footer/ifacebook.svg';
import INSTAGRAM from '../../images/footer/iinstagram.svg';
import LOGO from '../../images/logo.svg';
import { Link } from 'react-router-dom';
import { ROUTES } from '../../utils/routes';

const Footer = () => {
  return (
    <>
        <section className={styles.footer}>
            <div className={styles.infoblock}>
                <p>Test Task</p>
                
            </div>
           
            <div className={styles.socials}>   
                 <p>Test Task</p>
            </div>  
        </section>
    </>
  )
}

export default Footer