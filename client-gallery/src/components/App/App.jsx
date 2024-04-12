import React, { useEffect } from "react";
import AppRoutes from "../Routes/Routes";
import Header from "../Header/Header";
import Footer from "../Footer/Footer";

import styles from '../../styles/App.module.css';
import { useDispatch } from "react-redux";
import { initializeCartFromLocalStorage } from "../../features/user/userSlice";

const App = () => {
    const dispatch = useDispatch();

  useEffect(() => {
    dispatch(initializeCartFromLocalStorage());
  }, [dispatch]);
    return(
        <div className={styles.App}>
            <Header />
                <AppRoutes/>
            <Footer />
        </div>
    )
}
export default App;  