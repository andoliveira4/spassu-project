import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useParams, useNavigate } from 'react-router-dom';
import './CreateProduct.css';

function CreateProduct() {
  const { productId } = useParams();
  const navigate = useNavigate();
  const [product, setProduct] = useState({
    productName: '',
    productQuantity: 0,
    productPrice: 0,
    active: true,
  });
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    if (productId) {
      const fetchProduct = async () => {
        setLoading(true);
        try {
          const response = await axios.get(`https://localhost:7211/api/product/${productId}`);
          setProduct(response.data);
          setLoading(false);
        } catch (error) {
          setError('Error fetching product details');
          setLoading(false);
        }
      };
      fetchProduct();
    }
  }, [productId]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setProduct({ ...product, [name]: value });
  };

  const handleCheckboxChange = (e) => {
    const { name, checked } = e.target;
    setProduct({ ...product, [name]: checked });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    const productData = {
      ...product,
      createdAt: new Date().toISOString(),
      updatedAt: new Date().toISOString(),
    };

    try {
      if (productId) {
        await axios.put(`https://localhost:7211/api/product/${productId}`, productData);
        alert('Product updated successfully!');
      } else {
        await axios.post('https://localhost:7211/api/product', productData);
        alert('Product created successfully!');
      }
      navigate('/product-list');
    } catch (error) {
      setError('Error occurred while saving the product');
      setLoading(false);
    }
  };

  if (loading) {
    return <div className="loading-spinner">Loading...</div>;
  }

  return (
    <div className="create-product-container">
      <h1>{productId ? 'Editar Produto' : 'Criar Produto'}</h1>
      {error && <div className="error-message">{error}</div>}
      <form onSubmit={handleSubmit} className="product-form">
        <div className="form-group">
          <label htmlFor="productName">Nome Produto</label>
          <input
            type="text"
            id="productName"
            name="productName"
            value={product.productName}
            onChange={handleChange}
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="productQuantity">Quantidade</label>
          <input
            type="number"
            id="productQuantity"
            name="productQuantity"
            value={product.productQuantity}
            onChange={handleChange}
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="productPrice">Preço</label>
          <input
            type="number"
            id="productPrice"
            name="productPrice"
            value={product.productPrice}
            onChange={handleChange}
            step="0.01"
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="active">Ativo</label>
          <input
            type="checkbox"
            id="active"
            name="active"
            checked={product.active}
            onChange={handleCheckboxChange}
          />
        </div>

        <button type="submit" className="submit-btn">
          {productId ? 'Update Product' : 'Criar Produto'}
        </button>
      </form>
    </div>
  );
}

export default CreateProduct;
