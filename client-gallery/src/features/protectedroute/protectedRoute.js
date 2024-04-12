import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';

const ProtectedRoute = () => {
    const cart = JSON.parse(localStorage.getItem('cart'));

    if (!cart || cart.length === 0) {
      return <Navigate to='/checkout' />;
    }
  return (
    <Outlet />
  );
};
export default ProtectedRoute;