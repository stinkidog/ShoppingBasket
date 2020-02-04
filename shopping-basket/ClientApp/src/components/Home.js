import React, { Component } from 'react';
import { Form, FormGroup, Input, Label, Container, Row, Col, Button } from 'reactstrap';
import './Home.css';

export class Home extends Component {

    constructor(props) {
        super(props);

        this.state = {
            products: [],
            giftVouchers: [],
            offerVouchers: [],
            basket: {
                finalTotal: 0.00,
                products: [],
                giftVouchers: [],
                offerVoucher: {}   
            },
            selectedProduct: null,
            selectedGiftVoucher: null,
            selectedOfferVoucher: null
        };     
    }

    async componentDidMount() {
        await this.loadProducts();
        await this.loadGiftVouchers();
        await this.loadOfferVouchers();
        await this.calculateBasket();
    }

    loadProducts = () => {
        fetch('api/Basket/GetAllAvailableProducts')
            .then(response => response.json())
            .then(data => {
                this.setState({
                    products: data,
                    selectedProduct: data[0]
                });
            });
    }

    loadGiftVouchers = () => {
        fetch('api/Basket/GetAllAvailableGiftVouchers')
            .then(response => response.json())
            .then(data => {
                this.setState({
                    giftVouchers: data,
                    selectedGiftVoucher: data[0]
                });
            });
    }

    loadOfferVouchers = () => {
        fetch('api/Basket/GetAllAvailableOfferVouchers')
            .then(response => response.json())
            .then(data => {
                this.setState({
                    offerVouchers: data,
                    selectedOfferVoucher: data[0]
                });
            });
    }

    calculateBasket = () => {

        fetch('api/Basket/ProcessBasket', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(this.state.basket)
        })
            .then(response => response.json())
            .then(data => {
                this.setState({ basket: data });
            });
    }

    addProduct = () => {

        var product = this.state.selectedProduct;

        this.setState(prevState => ({
            ...prevState,
            basket: {
                ...prevState.basket,
                products: [
                    ...prevState.basket.products,
                    product
                ]
            }
        }),
            this.calculateBasket
        )
    }

    addGiftVoucher = () => {

        var giftVoucher = this.state.selectedGiftVoucher;

        this.setState(prevState => ({
            ...prevState,
            basket: {
                ...prevState.basket,
                giftVouchers: [
                    ...prevState.basket.giftVouchers,
                    giftVoucher
                ]
            }
        }),
            this.calculateBasket
        )
    }

    addOfferVoucher = () => {

        var offerVoucher = this.state.selectedOfferVoucher;

        this.setState(prevState => ({
            ...prevState,
            basket: {
                ...prevState.basket,
                offerVoucher: offerVoucher
            }
        }),
            this.calculateBasket
        )
    }

    updateSelectedProduct = (event) => {

        //In reality this statement (and other similar) would use an ID
        var product = this.state.products.find(prod => prod.name === event.target.value);

        this.setState({
            selectedProduct: product
        });
    }

    updateSelectedGiftVoucher = (event) => {

        var giftVoucher = this.state.giftVouchers(vouch => vouch.name === event.target.value);

        this.setState({
            selectedGiftVoucher: giftVoucher
        });
    }

    updateSelectedOfferVoucher = (event) => {

        var offerVoucher = this.state.offerVouchers(vouch => vouch.name === event.target.value);

        this.setState({
            selectedOfferVoucher: offerVoucher
        });
    }

    render() {
        return (
            <Container>

                <Row className="selectionRow">
                    <Col md="3">
                        <Label for="productSelection">Choose a Product</Label>
                    </Col>
                    <Col md="7">
                        <Input type="select" name="products" id="productSelection" placeholder="Select a Product..." onChange={(selected) => this.updateSelectedProduct(selected)}>
                            {this.state.products.map((product) => <option>{product.name}</option>)}
                        </Input>
                    </Col>
                    <Col md="2">
                        <Button onClick={() => this.addProduct()}>Add Product</Button>
                    </Col>
                </Row>

                <Row className="selectionRow">
                    <Col md="3">
                        <Label for="giftVoucherSelection">Select any gift vouchers you have</Label>
                    </Col>
                    <Col md="7">
                        <Input type="select" name="giftVouchers" id="giftVouchersSelection" placeholder="Select a Gift Voucher..." onChange={(selected) => this.updateSelectedGiftVoucher(selected)}>
                            {this.state.giftVouchers.map((giftVoucher) => <option> { giftVoucher.name }</option>)}
                        </Input>
                    </Col>
                    <Col md="2">
                        <Button onClick={() => this.addGiftVoucher()}> Add Gift</Button>
                    </Col>
                </Row>

                <Row className="selectionRow">
                    <Col md="3">
                        <Label for="offerVoucherSelection">Select any gift vouchers you have</Label>
                    </Col>
                    <Col md="7">
                        <Input type="select" name="offerVouchers" id="offerVoucherSelection" placeholder="Select an Offer Voucher..." onChange={(selected) => this.updateSelectedOfferVoucher(selected)}>
                            {this.state.offerVouchers.map((offerVoucher) => <option>{offerVoucher.name}</option>)}
                        </Input>
                    </Col>
                    <Col md="2">
                        <Button onClick={() => this.addOfferVoucher()}>Add Offer</Button>
                    </Col>

                </Row>

                <Row className="selectionRow">
                    <Col>
                        <h3>Products</h3>
                    </Col>
                </Row>
                {this.state.basket.products.map((product) =>
                    <Row className="selectionRow">
                        <Col md={2}>{product.name}</Col>
                        <Col md={10}>&#163;{product.price}</Col>
                    </Row>
                )}

                <Row className="selectionRow">
                    <Col>
                        <h3>Gift Vouchers</h3>
                    </Col>
                </Row>
                {this.state.basket.giftVouchers.map((voucher) =>
                    <Row className="selectionRow">
                        <Col md={2}>{voucher.name}</Col>
                        <Col md={10}>&#163;{voucher.value}</Col>
                    </Row>
                )}

                <Row className="selectionRow">
                    <Col>
                        <h3>Offer Voucher</h3>
                    </Col>
                </Row>
                <Row className="selectionRow">
                    <Col md={4}>{this.state.basket.offerVoucher.name}</Col>
                    <Col md={8}>&#163;{this.state.basket.offerVoucher.value}</Col>
                </Row>

                <Row className="selectionRow">
                    <Col>
                        <h3>Total: &#163;{this.state.basket.finalTotal}</h3>
                    </Col>
                </Row>

                <Row className="selectionRow">
                    <Col>
                        {this.state.basket.errorMessage}
                    </Col>
                </Row>

            </Container>
        );
    }
}
