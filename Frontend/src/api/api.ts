import { ClientBase } from "./client-base";

export class Client extends ClientBase {
  private http: {
      fetch(url: RequestInfo, init?: RequestInit): Promise<Response>;
  };
  private baseUrl: string;
  protected jsonParseReviver: ((key: string, value: any) => any) | undefined =
      undefined;

  constructor(
      baseUrl?: string,
      http?: {
          fetch(url: RequestInfo, init?: RequestInit): Promise<Response>;
      }
  ) {
      super();
      this.http = http ? http : <any>window;
      this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : '';
  }

  /**
   * @return Success
   */
  getAll(version: string): Promise<ResultListVm> {
      let url_ = this.baseUrl + '/api/{version}/get/all';
      if (version === undefined || version === null)
          throw new Error("The parameter 'version' must be defined.");
      url_ = url_.replace('{version}', encodeURIComponent('' + version));
      url_ = url_.replace(/[?&]$/, '');

      let options_ = <RequestInit>{
          method: 'GET',
          mode: 'cors',
          headers: {
              Accept: 'application/json',
          },
      };

      return this.transformOptions(options_)
          .then((transformedOptions_) => {
              return this.http.fetch(url_, transformedOptions_);
          })
          .then((_response: Response) => {
              return this.processGetAll(_response);
          });
  }

  protected processGetAll(response: Response): Promise<ResultListVm> {
      const status = response.status;
      let _headers: any = {};
      if (response.headers && response.headers.forEach) {
          response.headers.forEach((v: any, k: any) => (_headers[k] = v));
      }
      if (status === 200) {
          return response.text().then((_responseText) => {
              let result200: any = null;
              result200 =
                  _responseText === ''
                      ? null
                      : <ResultListVm>(
                            JSON.parse(_responseText, this.jsonParseReviver)
                        );
              return result200;
          });
      } else if (status === 401) {
          return response.text().then((_responseText) => {
              let result401: any = null;
              result401 =
                  _responseText === ''
                      ? null
                      : <ProblemDetails>(
                            JSON.parse(_responseText, this.jsonParseReviver)
                        );
              return throwException(
                  'Unauthorized',
                  status,
                  _responseText,
                  _headers,
                  result401
              );
          });
      } else if (status !== 200 && status !== 204) {
          return response.text().then((_responseText) => {
              return throwException(
                  'An unexpected server error occurred.',
                  status,
                  _responseText,
                  _headers
              );
          });
      }
      return Promise.resolve<ResultListVm>(<any>null);
  }

  /**
   * @return Success
   */
  getCertain(version: string, quantity: number): Promise<ResultListVm> {
    let url_ = this.baseUrl + '/api/{version}/get/{quantity}';
    if (version === undefined || version === null)
        throw new Error("The parameter 'version' must be defined.");
    url_ = url_.replace('{version}', encodeURIComponent('' + version));
    url_ = url_.replace(/[?&]$/, '');

    let options_ = <RequestInit>{
        method: 'GET',
        mode: 'cors',
        headers: {
            Accept: 'application/json',
        },
    };

    return this.transformOptions(options_)
        .then((transformedOptions_) => {
            return this.http.fetch(url_, transformedOptions_);
        })
        .then((_response: Response) => {
            return this.processGetCertain(_response);
        });
}

protected processGetCertain(response: Response): Promise<ResultListVm> {
    const status = response.status;
    let _headers: any = {};
    if (response.headers && response.headers.forEach) {
        response.headers.forEach((v: any, k: any) => (_headers[k] = v));
    }
    if (status === 200) {
        return response.text().then((_responseText) => {
            let result200: any = null;
            result200 =
                _responseText === ''
                    ? null
                    : <ResultListVm>(
                          JSON.parse(_responseText, this.jsonParseReviver)
                      );
            return result200;
        });
    } else if (status === 401) {
        return response.text().then((_responseText) => {
            let result401: any = null;
            result401 =
                _responseText === ''
                    ? null
                    : <ProblemDetails>(
                          JSON.parse(_responseText, this.jsonParseReviver)
                      );
            return throwException(
                'Unauthorized',
                status,
                _responseText,
                _headers,
                result401
            );
        });
    } else if (status !== 200 && status !== 204) {
        return response.text().then((_responseText) => {
            return throwException(
                'An unexpected server error occurred.',
                status,
                _responseText,
                _headers
            );
        });
    }
    return Promise.resolve<ResultListVm>(<any>null);
}

  /**
   * @param body (optional)
   * @return Success
   */
  create(version: string, body: CreateResultDto | undefined): Promise<string> {
      let url_ = this.baseUrl + '/api/{version}/add';
      if (version === undefined || version === null)
          throw new Error("The parameter 'version' must be defined.");
      url_ = url_.replace('{version}', encodeURIComponent('' + version));
      url_ = url_.replace(/[?&]$/, '');

      const content_ = JSON.stringify(body);

      let options_ = <RequestInit>{
          body: content_,
          method: 'POST',
          mode: 'cors',
          headers: {
              'Content-Type': 'application/json',
          },
      };

      return this.transformOptions(options_)
          .then((transformedOptions_) => {
              return this.http.fetch(url_, transformedOptions_);
          })
          .then((_response: Response) => {
              return this.processCreate(_response);
          });
  }

  protected processCreate(response: Response): Promise<string> {
      const status = response.status;
      let _headers: any = {};
      if (response.headers && response.headers.forEach) {
          response.headers.forEach((v: any, k: any) => (_headers[k] = v));
      }
      if (status === 201) {
          return response.text().then((_responseText) => {
              let result201: any = null;
              result201 =
                  _responseText === ''
                      ? null
                      : <string>(
                            JSON.parse(_responseText, this.jsonParseReviver)
                        );
              return result201;
          });
      } else if (status === 401) {
          return response.text().then((_responseText) => {
              let result401: any = null;
              result401 =
                  _responseText === ''
                      ? null
                      : <ProblemDetails>(
                            JSON.parse(_responseText, this.jsonParseReviver)
                        );
              return throwException(
                  'Unauthorized',
                  status,
                  _responseText,
                  _headers,
                  result401
              );
          });
      } else if (status !== 200 && status !== 204) {
          return response.text().then((_responseText) => {
              return throwException(
                  'An unexpected server error occurred.',
                  status,
                  _responseText,
                  _headers
              );
          });
      }
      return Promise.resolve<string>(<any>null);
  }
}

export interface CreateResultDto {
  reactionTime: number;
  testDate: Date;
}

export interface ResultListVm {
  results?: ResultVm[] | undefined;
}

export interface ResultVm {
  reactionTime: number;
  testDate: Date;
}

export interface ProblemDetails {
  type?: string | undefined;
  title?: string | undefined;
  status?: number | undefined;
  detail?: string | undefined;
  instance?: string | undefined;
}

export class ApiException extends Error {
  message: string;
  status: number;
  response: string;
  headers: { [key: string]: any };
  result: any;

  constructor(
      message: string,
      status: number,
      response: string,
      headers: { [key: string]: any },
      result: any
  ) {
      super();

      this.message = message;
      this.status = status;
      this.response = response;
      this.headers = headers;
      this.result = result;
  }

  protected isApiException = true;

  static isApiException(obj: any): obj is ApiException {
      return obj.isApiException === true;
  }
}

function throwException(
  message: string,
  status: number,
  response: string,
  headers: { [key: string]: any },
  result?: any
): any {
  if (result !== null && result !== undefined) throw result;
  else throw new ApiException(message, status, response, headers, null);
}