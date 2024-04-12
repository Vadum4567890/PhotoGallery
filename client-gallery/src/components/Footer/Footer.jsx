import React from 'react'
import styles from '../../styles/Footer.module.css';

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